using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class ColorManager : Singleton<ColorManager>{

    public List<Material> materials;
    public List<ColorSetup> colorSetups;

    public void ChangeColorByType(ArtManager.ArtType artType){

        var setup = colorSetups.Find(i => i.artType == artType);

        for (int i = 0; i < materials.Count; i++){ // buscando variáveis no materials
            materials[i].SetColor("_Color", setup.colors[i]); // colocando color na variável do standard da properties no _Color 
        }
    }

}

[System.Serializable]
public class ColorSetup{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}