using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuTheme : MonoBehaviour
{
    

    private void OnEnable()
    {

        for (int i = 0; i < 5; i++)
        {
            int index = i;
            transform.GetChild(0).GetChild(i).GetComponent<Button>().onClick.AddListener(() => OnSelectTheme(index));

        }

        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => OnSelectBack());

    }

    void OnSelectTheme(int indexTheme)
    {
        TempGameManager.indexTheme = indexTheme;
        transform.parent.GetChild(2).gameObject.SetActive(true);

        resetMenu();
        gameObject.SetActive(false);

    }

    void OnSelectBack()
    {
        transform.parent.GetChild(0).gameObject.SetActive(true);
        resetMenu();
        TempGameManager.indexTheme = -1;
        gameObject.SetActive(false);

      
    }


    void resetMenu()
    {
        for (int i = 0; i < 5; i++)
        {
            transform.GetChild(0).GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();
        }
     
    }

}
