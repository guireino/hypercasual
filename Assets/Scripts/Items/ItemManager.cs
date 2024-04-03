using System.Collections;
using System.Collections.Generic;
using Ebac.Core.Singleton;
using UnityEngine;
using TMPro;

public class ItemManager : Singleton<ItemManager>{

    //public static ItemManager Instance;

    public SOInt coins;
    public TextMeshProUGUI uiTextCoins;

    // private void Awake() {

    //     if(Instance == null){
    //         Instance = this;
    //     }else{
    //         Destroy(gameObject);
    //     }
    // }

    private void Start(){
        Reset();
    }

    private void Reset(){
        coins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1){
        coins.value += amount;
        UpdateUI();
    }

    private void UpdateUI(){ // usamos SOUIIntUpdate para atualizar UI coins
       // uiTextCoins.text = coins.ToString(); // método clássico para atualizar UI coins
       //UIInGameManager.Instance.UpdateTextCoins(coins.ToString());
       //UIInGameManager.UpdateTextCoins(coins.value.ToString());
    }

}