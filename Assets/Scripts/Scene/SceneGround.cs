using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGround : SceneLoader
{
    
    protected override void sceneLoad()
    {

        themeType myType = (themeType)TempGameManager.indexTheme;
        string nameTheme = myType.ToString();
       
        int index = TempGameManager.indexLevel;

        Debug.Log(TempGameManager.indexTheme);
        Debug.Log(TempGameManager.indexLevel);
        string path = "Prefabs/" + nameTheme +"_"+ index.ToString();

        GameObject gamePrefab = Resources.Load(path) as GameObject;
        GameObject obj = Instantiate(gamePrefab);
    }

}
