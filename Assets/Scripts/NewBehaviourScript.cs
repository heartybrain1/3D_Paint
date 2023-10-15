using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            int index = i;
            transform.GetChild(1).GetChild(0).GetChild(i).GetChild(0).GetComponent<Button>().onClick.AddListener(() => OnSelectPaintable(index));

        }
    }



    void OnSelectPaintable(int index)
    {
      
        TempGameManager.indexPaintable = index;

        SceneManager.LoadScene("3_Sketch");

    }
}
