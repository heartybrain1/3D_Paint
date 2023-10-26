using UnityEngine;

public class SimpleCameraZoomAmdOrbit : MonoBehaviour
{
    public Transform target; // 타겟 오브젝트
    public float distance = 5.0f; // 카메라와 타겟 간의 거리
    public float sensitivity = 2.0f; // 마우스 회전 감도
    public float zoomSpeed = 2.0f; // 확대 및 축소 속도
    public float minDistance = 2.0f; // 최소 거리
    public float maxDistance = 10.0f; // 최대 거리

    private float currentDistance;

    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    private bool isPanning = false;
    private Vector3 lastMousePosition;
    public float panSpeed;

    private void Start()
    {
        currentDistance = distance;
    }

    private void Update()
    {
        // 마우스 회전
        if (Input.GetMouseButton(0)) // 마우스 왼쪽 버튼 클릭 시
        {
            xRotation += Input.GetAxis("Mouse X") * sensitivity;
            yRotation -= Input.GetAxis("Mouse Y") * sensitivity;
            yRotation = Mathf.Clamp(yRotation, -90, 90); // 위/아래로 너무 회전하지 않도록 제한
        }


        // 모바일 터치 회전 (Swipe)
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                xRotation += touch.deltaPosition.x * sensitivity * 0.1f;
                yRotation -= touch.deltaPosition.y * sensitivity * 0.1f;
                yRotation = Mathf.Clamp(yRotation, -90, 90);
            }
        }

        // 확대 및 축소
        currentDistance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        // 최소 및 최대 거리 제한
        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

        // 카메라 위치 계산
        Vector3 dir = new Vector3(0, 0, -currentDistance);
        Quaternion rotation = Quaternion.Euler(yRotation, xRotation, 0);
        transform.position = target.position + rotation * dir;
        transform.LookAt(target.position);



    }
}