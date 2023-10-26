using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public GameObject obj;
   
    void Start()
    {
        Bounds bounds =
        obj.GetComponent<Collider>().bounds;

        Camera camera = GetComponent<Camera>();

        float cameraDistance = 2.0f; // Constant factor
        Vector3 objectSizes = bounds.max - bounds.min;
        float objectSize = Mathf.Max(objectSizes.x, objectSizes.y, objectSizes.z);
        float cameraView = 2.0f * Mathf.Tan(0.5f * Mathf.Deg2Rad * camera.fieldOfView); // Visible height 1 meter in front
        float distance = cameraDistance * objectSize / cameraView; // Combined wanted distance from the object
        distance += 0.5f * objectSize; // Estimated offset from the center to the outside of the object
        camera.transform.position = bounds.center - distance * camera.transform.forward;
    }

   
}
