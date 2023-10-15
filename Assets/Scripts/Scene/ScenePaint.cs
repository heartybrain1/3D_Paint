using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePaint : SceneLoader
{
    
    protected override void sceneLoad()
    {


     

        themeType myType = (themeType)TempGameManager.indexTheme;
        string nameTheme = myType.ToString();

        int index = TempGameManager.indexLevel;

        Debug.Log(TempGameManager.indexTheme);
        Debug.Log(TempGameManager.indexLevel);
        Debug.Log(TempGameManager.indexPaintable);

        string path = "Prefabs/Paintable/" + nameTheme + "_" + index.ToString() + "_" + TempGameManager.indexPaintable.ToString();

        GameObject gamePrefab = Resources.Load(path) as GameObject;
        GameObject obj = Instantiate(gamePrefab);
    }

}
