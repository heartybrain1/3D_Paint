using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuLevel : MonoBehaviour
{
    private void OnEnable()
    {

        for (int i = 0; i < 5; i++)
        {
            int index = i;
            transform.GetChild(0).GetChild(i).GetComponent<Button>().onClick.AddListener(() => OnSelectLevel(index));

        }

        themeType indexTheme = (themeType)TempGameManager.indexTheme;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = indexTheme.ToString();

        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => OnSelectBack());

       

    }

    void OnSelectLevel(int indexLevel)
    {
        TempGameManager.indexLevel = indexLevel;
        SceneManager.LoadScene("2_Play");
    }

    void OnSelectBack()
    {
        transform.parent.GetChild(1).gameObject.SetActive(true);
        resetMenu();
        TempGameManager.indexLevel = -1;
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
