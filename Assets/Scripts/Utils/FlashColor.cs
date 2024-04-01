using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour{

    //private Tween _currentTween;

    public List<SpriteRenderer> spriteRenderers;
    public Color color = Color.red;
    public float duration = .3f;

    private void OnValidate() {

        spriteRenderers = new List<SpriteRenderer>();

        //buscando dos objetos sprites
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>()){
            spriteRenderers.Add(child);
        }
    }

    private void Update(){

        if(Input.GetKeyDown(KeyCode.A)){
            Flash();
        }
    }

    public void Flash(){

        //verificar se tween esta com um cor
        // if(_currentTween != null){
        //     //_currentTween.Kill();
        //     spriteRenderers.ForEach(i => i.color = Color.white); // resetando cor original do personagem
        // }

        //fazendo animation da cor
        foreach (var s in spriteRenderers){
            //_currentTween = s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }
   
}