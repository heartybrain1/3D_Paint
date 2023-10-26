using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lovatto.OrbitCamera;

public class GroundManager : MonoBehaviour
{
    public static GroundManager Instance;

    public bl_CameraOrbit Orbit;
    public bl_OrbitTargetPlaceholder[] placeholdersTargets;



    public int CurrentTarget = 0;
    private void Update()
    {
        calculateDistanceIcon();



    }

    void calculateDistanceIcon()
    {
        float distance = Vector3.Distance(placeholdersTargets[CurrentTarget].transform.position, Orbit.transform.position);
     
        if(distance<2f)
        {
            UIManager.Instance.updateVisibleIcon(CurrentTarget, true);
        }
        else
        {
            UIManager.Instance.updateVisibleIcon(CurrentTarget, false);

        }


    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        int count = transform.childCount;
        placeholdersTargets = new bl_OrbitTargetPlaceholder[5];
        for (int i = 0; i < count; i++)
        {
            int index = i;
            Debug.Log(index);
            placeholdersTargets[i]= transform.GetChild(index).GetComponent<bl_OrbitTargetPlaceholder>();

            //worldUI.GetChild(index).GetComponent<bl_OrbitTargetPlaceholder>().onClick.AddListener(() => OnSelectIcon(index));
        }
    }

   
    public void ChangeTarget(int index)
    {
        Orbit.SetTarget(placeholdersTargets[index]);
      
    }

    public void OnClickToggleInteraction(bool b)
    {

        Orbit.Interact = b;
    }
}
