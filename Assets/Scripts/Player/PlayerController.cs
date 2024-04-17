using System;
using System.Collections;
using System.Collections.Generic;
using Ebac.Core.Singleton;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>{

    private Vector3 _pos, _startPosition;
    private float _currentSpeed;
    private bool _canRun;

    [Header("Lerp")]
    public GameObject endScreen;
    public Transform target;
    public float lerpSpeed = 1f;
    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    [Header("TextMeshPro")]
    public TextMeshPro uiTextPowerUp;

    [Header("PowerUps")]
    public bool invincible = false;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    private void Start() {
        _startPosition = transform.position; //salvando posição original 
        ResetSpeed();
    }

    // Update is called once per frame
    public void Update(){

        if(!_canRun) return; // se ele nao poder corre ele nao passa da aqui

        _pos = target.position; // criando variável para pegar position

        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision col) {
        if(col.transform.tag == tagToCheckEnemy){
            if(!invincible) EndGame();
        }
    }

    public void OnTriggerEnter(Collider col) {
        if(col.transform.tag == tagToCheckEndLine){
           if(!invincible) EndGame();
        }
    }

    private void EndGame(){
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun(){
        _canRun = true;
    }

    #region POWER UPS

    public void SetPowerUpText(string s){
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f){
        _currentSpeed = f;
    }

    public void ResetSpeed(){
        _currentSpeed = speed;
    }

    public void SetInvencible(bool b = true){
        invincible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease){
        /*
        var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        //fazendo animação com o movimento no y
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight(){

        transform.DOMoveY(_startPosition.y, .1f);
        /*
        var p = transform.position; // vai pegar posição voltar original
        p.y = _startPosition.y;
        transform.position = p; */
    }

    public void ChangeCoinCollectorSize(float amount){ //mudando o tamanha coinCollector
        coinCollector.transform.localScale = Vector3.one * amount;
        Debug.Log("ChangeCoinCollectorSize coinCollector " + coinCollector);
    }

    #endregion

}