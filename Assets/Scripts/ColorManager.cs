using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CW.Common;
using PaintIn3D;

public enum brushType { brush_0, brush_1, brush_2, brush_3, brush_4, brush_5, brush_6 }
public enum toolType { toolBrush, toolDot, toolLine, tool_3, type_4, type_5, type_6 }

public class ColorManager : MonoBehaviour
{


    public static ColorManager Instance;

    public FlexibleColorPicker fcp;


    public Color[] userColors = new Color[] { };
    public Color[] currentColors = new Color[] { };
    public int indexSelectedColor;
    public Transform tColorPalette;

    public Transform tmpBrushTools;

    private void Awake()
    {
        Instance = this;
    }
    private void OnChangeColor(Color co)
    {

        currentColors[indexSelectedColor] = co;
        tColorPalette.GetChild(1).GetChild(indexSelectedColor).GetChild(0).GetComponent<Image>().color = co;

        for (int i = 0; i < 1; i++)
        {
            tmpBrushTools.GetChild(i).GetComponent<P3dPaintSphere>().Color = co;

        }

        Debug.Log(co);
      
    }
    void Start()
    {

        initiateColors();
        fcp.onColorChange.AddListener(OnChangeColor);
      
    }

  

    public void OnSelectColor(int index)
    {

        tmpBrushTools.GetChild(0).gameObject.SetActive(true);
        tmpBrushTools.GetChild(6).gameObject.SetActive(false);
        indexSelectedColor = index;

        for (int i = 0; i < 5; i++)
        {
          
            tColorPalette.GetChild(1).GetChild(i).GetComponent<Image>().enabled = false;
        }
        tColorPalette.GetChild(1).GetChild(indexSelectedColor).GetComponent<Image>().enabled = true;



        for (int i = 0; i < 1; i++)
        {
            tmpBrushTools.GetChild(i).GetComponent<P3dPaintSphere>().Color = currentColors[indexSelectedColor];

        }

        fcp.SetColor(currentColors[indexSelectedColor]);


    }

    public void OnPressedColor(int index)
    {
      

      
    }

   


    void initiateColors()
    {
        currentColors = userColors;
        indexSelectedColor = 0;

        for (int i = 0; i < 5; i++)
        {
            tColorPalette.GetChild(1).GetChild(i).GetChild(0).GetComponent<Image>().color = currentColors[i];
            tColorPalette.GetChild(1).GetChild(i).GetComponent<Image>().enabled = false;
        }
        tColorPalette.GetChild(1).GetChild(indexSelectedColor).GetComponent<Image>().enabled = true;

        for (int i = 0; i < 1; i++)
        {
            tmpBrushTools.GetChild(i).GetComponent<P3dPaintSphere>().Color = currentColors[indexSelectedColor];

        }
    }
}
