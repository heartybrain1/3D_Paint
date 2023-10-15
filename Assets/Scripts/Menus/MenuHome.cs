using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHome : MonoBehaviour
{

    private void OnEnable()
    {
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => setMenuTheme());
       
    }


    void setMenuTheme()
    {
        transform.parent.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();

        gameObject.SetActive(false);

    }




}
