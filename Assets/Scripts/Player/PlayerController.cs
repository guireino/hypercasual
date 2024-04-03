using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Vector3 _pos;
    private bool _canRun;

    [Header("Lerp")]
    public GameObject endScreen;
    public Transform target;
    public float lerpSpeed = 1f;
    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    // Update is called once per frame
    public void Update(){

        if(!_canRun) return; // se ele nao poder corre ele nao passa da aqui

        _pos = target.position; // criando variável para pegar position

        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision col) {
        if(col.transform.tag == tagToCheckEnemy){
            EndGame();
        }
    }

    public void OnTriggerEnter(Collider col) {
        if(col.transform.tag == tagToCheckEndLine){
            EndGame();
        }
    }

    private void EndGame(){
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun(){
        _canRun = true;
    }
}