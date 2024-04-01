using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour{

    public void Pause(){
        Time.timeScale = 0; // timeScale = 0 deixa no 0 faz com que tempo fica parado do jogo, para verificar o time scale do jogo vai nas Project Settings e no Time
    }
    
    public void Unpause(){
        Time.timeScale = 1;
    }
   
}