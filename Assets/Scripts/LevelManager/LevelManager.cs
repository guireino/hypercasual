using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour{
    
    private GameObject _currentLevel;
    [SerializeField] private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBasedSetup _currentSetup;
    //private List<GameObject> _spawnedPieces;

    public Transform container;
    public List<GameObject> levels;
    public List<LevelPieceBasedSetup> levelPieceBasedSetups;

    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;

    //[Header("Pieces")]

    /*
    public List<LevelPieceBase> levelPiecasStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecasEnd;
    public int piecesNumber = 5, piecesStartNumber = 3, piecesEndNumber = 1;
    public float timeBetweenPieces = .3f;
    */

    [SerializeField] private int _index;

    private void Awake() {
        //SpawnNextLevel();
        CreateLevelPieces();
    }

    private void SpawnNextLevel(){

        if(_currentLevel != null){
            Destroy(_currentLevel); // vai deletar ele para criar outro
            _index++;

            //0 >= 2
            if (_index >= levels.Count){ // verificar se valor e maior que os leveis
                ResetLevelIndex();
            }
        }

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex(){
         _index = 0; // se valor for maior que os levels ele volta para 0
    }

    #region 
    
    private void CreateLevelPieces(){
        //StartCoroutine(CreateLevelPiecesCoroutine());

        //_spawnedPieces = new List<LevelPieceBase>();
        CleanSpawnedPieces();

        if (_currentSetup != null){

            _index++;

            if(_index >= levelPieceBasedSetups.Count){
                ResetLevelIndex();
            }
        }

        _currentSetup = levelPieceBasedSetups[_index];
    
        for (int i = 0; i < _currentSetup.piecesStartNumber; i++){ //percorre todas pesas list piecesStartNumber
            CreateLevelPiece(_currentSetup.levelPiecesStart);
        }

        for (int i = 0; i < _currentSetup.piecesNumber; i++){  //percorre todas pesas list piecesNumber
            CreateLevelPiece(_currentSetup.levelPieces);
        }

        for (int i = 0; i < _currentSetup.piecesEndNumber; i++){  //percorre todas pesas list piecesEndNumber
            CreateLevelPiece(_currentSetup.levelPiecesEnd);
        }
        
        //ColorManager.Instance.ChangeColorByType(_currentSetup.artType);
        StartCoroutine(ScalePiecesByTime());
    }
    
    IEnumerator ScalePiecesByTime(){

        foreach (var p in _spawnedPieces){
            p.transform.localScale = Vector3.zero;
        }

        yield return null;

        for (int i = 0; i < _spawnedPieces.Count; i++){
            _spawnedPieces[i].transform.DOScale(1, scaleDuration).SetEase(ease); // colocando animação ao criar level
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }

        CoinsAnimationManager.Instance.StartAnimations();
    }

    private void CreateLevelPiece(List<LevelPieceBase> list){

        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container); // instanciando pedaço e container da level onde vai fica os pedaços.

        if(_spawnedPieces.Count > 0){
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position; //colocar o ultimo posição e no inicial de cada pesa
            //Debug.Log("spawnedPiece.transform.position " + spawnedPiece.transform.position);
        }else{
            spawnedPiece.transform.localPosition = Vector3.zero;
        }

        foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>()){ // ele vai achar pesas das variável spawnedPiece
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currentSetup.artType).gameObject);
        }

        _spawnedPieces.Add(spawnedPiece);
    }

    private void CleanSpawnedPieces(){

        for (int i = _spawnedPieces.Count - 1; i >= 0; i--){ //deletando de trás para frente
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }

    // IEnumerator CreateLevelPiecesCoroutine(){
    //     _spawnedPieces = new List<LevelPieceBase>();

    //     for (int i = 0; i < piecesNumber; i++){ //percorre todas pesas
    //         CreateLevelPiece(levelPieces);
    //         yield return new WaitForSeconds(timeBetweenPieces);
    //     }
    // }

    #endregion

    private void Update() {

        if(Input.GetKeyDown(KeyCode.D)){
            //SpawnNextLevel();
            CreateLevelPieces();
        }
    }
}