using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentHelper : MonoBehaviour{

    private int _index = 0; // seve para controlar movimento
    public List<Transform> positions;
    public float duration = 1f;

    private void Start(){

        transform.position = positions[0].transform.position; //colocando na primeira posição
        NextIndex();

        StartCoroutine(StartMoviment());
    }

    private void NextIndex(){

        _index++;

        if (_index >= positions.Count){ // se index for maior list positions
            _index = 0;
        }
    }

    IEnumerator StartMoviment(){

        float time = 0;

        while(true){

            var currentPosition = transform.position;

            while(time < duration){

                transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, (time / duration));

                time += Time.deltaTime;
                yield return null;
            }

            NextIndex();
            time = 0;

            yield return null;
        }
    }
    
}