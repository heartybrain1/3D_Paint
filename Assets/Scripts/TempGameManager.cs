using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempGameManager : MonoBehaviour
{

    public static TempGameManager Instance;

    public static int indexTheme;
    public static int indexLevel;
    public static int indexPaintable;
  

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

   
}
