using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PaintManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatePaint()
    {
        SceneManager.LoadScene("2_Play");
        GameManager.indexPaintable = -1;

    }

    public void toggleTouchMode()
    {


    }
}
