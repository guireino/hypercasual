using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ebac.Core.Singleton{ // o namespace vai criar um pacote onde todas que tivera associação ele 

    // <T> e um parâmetro esta dizendo o tipo de class e where e para detalhar
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour{

        public static T Instance;

        private void Awake(){

            //verificando se tem instance objeto GameManager
            if(Instance == null){
                Instance = GetComponent<T>(); // pegando componente dando para referencia   
            }else{
                Destroy(gameObject);
            }
        }
    }
}