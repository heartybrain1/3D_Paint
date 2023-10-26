using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePaint : SceneLoader
{
    
    protected override void sceneLoad()
    {
        themeType myType = (themeType)GameManager.indexTheme;
        string nameTheme = myType.ToString();

        int index = GameManager.indexLevel;

        Debug.Log(GameManager.indexTheme);
        Debug.Log(GameManager.indexLevel);
        Debug.Log(GameManager.indexPaintable);

        string path = "Prefabs/Paintable/" + nameTheme + "_" + index.ToString() + "_" + GameManager.indexPaintable.ToString();

        GameObject gamePrefab = Resources.Load(path) as GameObject;
        GameObject obj = Instantiate(gamePrefab);
    }

}
