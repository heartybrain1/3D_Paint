using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


using UnityEngine.Audio;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;


    public Transform worldUI;
    public Transform screenUI;

    RectTransform[] recTransformIcon;

    bool icon = false;
    public Button btnImage;


    int count = 0;

    public Color colorInCircle;
    public Color colorOutCircle;
    public Color colorInLine;
    public Color colorOutLine;
    public Color colorPlayCircle;
    public Color colorPlayLine;

    private void Awake()
    {
        Instance = this;
        setButtonUI();

        initiateIcon();

    }
    public void Home()
    {
        SceneManager.LoadScene("1_Home");

    }

    void initiateIcon()
    {

        count = worldUI.childCount;

        recTransformIcon = new RectTransform[count];
        for (int i = 0; i < count; i++)
        {
            Debug.Log(i);
            recTransformIcon[i] = screenUI.GetChild(i).GetComponent<RectTransform>();
            recTransformIcon[i].localPosition = new Vector3(0, 0, 0);
        }
        icon = true;

    }
    public void OnIcon()
    {
        screenUI.gameObject.SetActive(true);
        icon = true;
    }
    public void OffIcon()
    {
        icon = false;
        screenUI.gameObject.SetActive(false);


    }
    public void toggleIcon()
    {
        bool b = screenUI.gameObject.activeInHierarchy;
        icon = !b;
        screenUI.gameObject.SetActive(!b);


    }


    private void Update()
    {
        if (icon)
        {




            for (int i = 0; i < count; i++)
            {
                Vector3 posWorldUI = worldUI.GetChild(i).GetChild(0).GetChild(0).position;


                if (IsVisible(posWorldUI, new Vector3(0, 0, 0), Camera.main))
                {


                    Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, posWorldUI);
                    Vector2 anchoredPosition = transform.InverseTransformPoint(screenPoint);
                    recTransformIcon[i].anchoredPosition = anchoredPosition;
                    recTransformIcon[i].gameObject.SetActive(true);

                    Vector3 direction = posWorldUI - Camera.main.transform.position;

                    if (Physics.Raycast(Camera.main.transform.position, direction, out var raycastHit, Mathf.Infinity, 1 << LayerMask.NameToLayer("wall")))
                    {
                        float distance1 = Vector3.Distance(Camera.main.transform.position, posWorldUI);
                        float distance2 = Vector3.Distance(Camera.main.transform.position, raycastHit.point);




                        if (distance1 > distance2)
                        {

                            recTransformIcon[i].GetComponent<Image>().color = colorOutCircle;
                            recTransformIcon[i].GetChild(0).GetComponent<Image>().color = colorOutLine;
                        }
                        else
                        {
                            recTransformIcon[i].GetComponent<Image>().color = colorInCircle;
                            recTransformIcon[i].GetChild(0).GetComponent<Image>().color = colorInLine;

                        }


                        /*
                        if (GroundManager.Instance.isPlaying[i])
                        {
                            recTransformIcon[i].GetComponent<Image>().color = colorPlayCircle;
                            recTransformIcon[i].GetChild(0).GetComponent<Image>().color = colorPlayLine;
                        }
                        else
                        {
                            if (distance1 > distance2)
                            {

                                recTransformIcon[i].GetComponent<Image>().color = colorOutCircle;
                                recTransformIcon[i].GetChild(0).GetComponent<Image>().color = colorOutLine;
                            }
                            else
                            {
                                recTransformIcon[i].GetComponent<Image>().color = colorInCircle;
                                recTransformIcon[i].GetChild(0).GetComponent<Image>().color = colorInLine;

                            }
                        }

                        */
                    }
                    else
                    {
                        //recTransformIcon[i].GetComponent<Image>().color = colorInCircle;
                       // recTransformIcon[i].GetChild(0).GetComponent<Image>().color = colorInLine;

                    }




                }
                else
                {
                    recTransformIcon[i].gameObject.SetActive(false);

                }
            }
        }


    }

    bool IsVisible(Vector3 pos, Vector3 boundSize, Camera camera)
    {
        var bounds = new Bounds(pos, boundSize);
        var planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }


    void setButtonUI()
    {
        int count = screenUI.childCount;
        for(int i=0; i<count; i++)
        {
            int index = i;
            screenUI.GetChild(index).GetChild(0).GetChild(0).GetComponent<Button>().onClick.AddListener(() => OnSelectIcon(index));

            screenUI.GetChild(index).GetChild(1).GetChild(0).GetComponent<Button>().onClick.AddListener(() => OnSelectPaintable(index));
            screenUI.GetChild(index).GetChild(1).GetChild(1).GetComponent<Button>().onClick.AddListener(() => OnSelectDescription(index));
        }


    }

    public void updateVisibleIcon(int index, bool b)
    {
        screenUI.GetChild(index).GetChild(0).gameObject.SetActive(!b);
        screenUI.GetChild(index).GetChild(1).gameObject.SetActive(b);
    }

    void OnSelectIcon(int index)
    {

        GameManager.indexCurrentTarget = index;
        GroundManager.Instance.CurrentTarget = index;
        GroundManager.Instance.ChangeTarget(index);


        int count = screenUI.childCount;
        for (int i = 0; i < count; i++)
        {

            screenUI.GetChild(i).GetChild(0).GetChild(0).GetComponent<Button>().interactable = true;
        }

       // screenUI.GetChild(index).GetChild(0).GetChild(0).GetComponent<Button>().interactable = false;
    }

   

    void OnSelectPaintable(int index)
    {
        GameManager.indexPaintable = index;
        SceneManager.LoadScene("3_Paint");
    }


    void OnSelectDescription(int index)
    {
        StartCoroutine(playImage());
    }



    public IEnumerator playImage()
    {
        btnImage.interactable = false;
       // ContentManager.Instance.isPlaying[1] = true;
       // ContentManager.Instance.contentGroup.transform.GetChild(7).GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);





        /*
        TextMeshProUGUI txtTitle = ContentManager.Instance.contentGroup.transform.GetChild(7).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI txtDescription = ContentManager.Instance.contentGroup.transform.GetChild(7).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();

        txtTitle.text = "";
        txtDescription.text = "";

        float delay = 0.005f;


        string fullTex = "CICA";
        string currentText = "";

        for (int i = 0; i < fullTex.Length; i++)
        {
            currentText = fullTex.Substring(0, i + 1);
            txtTitle.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(0.1f);

        fullTex ="CICA description";
        currentText = "";

        for (int i = 0; i < fullTex.Length; i++)
        {
            currentText = fullTex.Substring(0, i + 1);
            txtDescription.text = currentText;
            yield return new WaitForSeconds(delay);
        }
         */
        yield return new WaitForSeconds(5.0f);
      //  ContentManager.Instance.contentGroup.transform.GetChild(7).GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
       // ContentManager.Instance.isPlaying[1] = false;
        btnImage.interactable = true;

    }
}
