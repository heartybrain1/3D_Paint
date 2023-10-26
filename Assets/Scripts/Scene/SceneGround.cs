using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGround : SceneLoader
{
    
    protected override void sceneLoad()
    {
        themeType myType = (themeType)GameManager.indexTheme;
        string nameTheme = myType.ToString();
       
        int index = GameManager.indexLevel;

        Debug.Log(GameManager.indexTheme);
        Debug.Log(GameManager.indexLevel);
        string path = "Prefabs/" + nameTheme +"_"+ index.ToString();

        GameObject gamePrefab = Resources.Load(path) as GameObject;
        GameObject obj = Instantiate(gamePrefab);
    }

}
