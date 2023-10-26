using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public enum themeType {themeDinosaur, themeSafari, themeSF, themeSpaceStation, themeZombies, themeCity, themeOriental, themeMedieval,themeWar, themeCowboy, themeEgypt}

public class GameManager : MonoBehaviour
{
   

    public static GameManager Instance;

    public static bool isPlaying = false;

    public static int indexTheme;
    public static int indexLevel;
    public static int indexPaintable;

    public static int indexCurrentTarget=0;


   

    float m_Time;

    float m_Life;
    public float Life { get { return m_Life; } set { m_Life = value; } }

    private int m_Seq;
    public int Seq { get { return m_Seq; } set { m_Seq = value; } }

   


    bool[] m_OwendGECKO = new bool[5];
    public bool[] OwendGECKO { get { return m_OwendGECKO; } set { m_OwendGECKO = value; } }


    private bool m_Cleared;
    public bool Cleared { get { return m_Cleared; } set { m_Cleared = value; } }


    private Vector3 m_DPposition;
    public Vector3 DPposition { get { return m_DPposition; } set { m_DPposition = value; } }

    private Quaternion m_DProtation;
    public Quaternion DProtation { get { return m_DProtation; } set { m_DProtation = value; } }



    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }


}
