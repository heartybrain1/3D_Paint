using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraPan : MonoBehaviour
{
    private bool isPanning = false;
    private Vector3 lastMousePosition;
    public float panSpeed;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 중클릭 드래그로 카메라 팬
        if (Input.GetMouseButtonDown(2)) // 마우스 중간 버튼 클릭 시
        {
            isPanning = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(2)) // 마우스 중간 버튼 뗄 때
        {
            isPanning = false;
        }

        if (isPanning)
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            transform.Translate(-mouseDelta.x * panSpeed * Time.deltaTime, -mouseDelta.y * panSpeed * Time.deltaTime, 0);
            lastMousePosition = Input.mousePosition;
        }
    }
}
