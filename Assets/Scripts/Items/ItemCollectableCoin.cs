using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase{

    public Collider collider;
    public float lerp = 5f, minDistance = 1f;
    public bool collect = false;

    private void Start() {
        //CoinsAnimationManager.Instance.RegisterCoin(this);
    }

    protected override void OnCollect(){
        base.OnCollect();
        collider.enabled = false;
        collect = true;
        //PlayerController.Instance.Bounce();
    }


    protected override void Collect(){
        //base.Collect();
        OnCollect();
    }

    private void Update() {

        if(collect){

            //fazendo com moeda sega player mais rápido com o tempo
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);

            //verificando se player esta distance para moeda seguir ele
            if(Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance){
                HideItens();
                Destroy(gameObject);
            }
        }
    }

    public void HideItens(){
        collider.enabled = false;
    }
}