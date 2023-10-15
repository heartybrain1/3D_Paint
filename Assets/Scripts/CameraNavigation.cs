using UnityEngine;

public class CameraNavigation : MonoBehaviour
{
    public Transform target; // 회전 중심이 될 타겟 오브젝트
    public float rotationSpeed = 2.0f; // 회전 속도
    public float zoomSpeed = 2.0f; // 줌 속도
    public float minZoomDistance = 2.0f; // 최소 줌 거리
    public float maxZoomDistance = 20.0f; // 최대 줌 거리
    public float smoothTime = 0.3f; // 스무딩 시간
    public float minYAngle = -90f; // y축 회전 최소 각도
    public float maxYAngle = 90f; // y축 회전 최대 각도

    private float currentZoomDistance;
    private Vector3 smoothVelocity;
    private Vector3 lastMousePosition;

    private void Start()
    {
        currentZoomDistance = Mathf.Clamp(Vector3.Distance(transform.position, target.position), minZoomDistance, maxZoomDistance);
    }

    private void Update()
    {
        // 마우스 입력 또는 모바일 터치 입력 처리
        if (Input.GetMouseButton(0))
        {
            // 마우스를 클릭 드래그하거나 모바일 터치 스와이프 처리
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
            float rotationX = deltaMousePosition.y * rotationSpeed;
            float rotationY = -deltaMousePosition.x * rotationSpeed;

            // y축 회전 각도 제한
            transform.RotateAround(target.position, Vector3.up, rotationY);
            transform.RotateAround(target.position, transform.right, rotationX);

            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x = Mathf.Clamp(eulerAngles.x, minYAngle, maxYAngle);
            transform.eulerAngles = eulerAngles;
        }

        // 마우스 휠 또는 모바일 터치 pinch 처리
        float zoomInput = -Input.GetAxis("Mouse ScrollWheel") + GetPinchZoom();
        currentZoomDistance += zoomInput * zoomSpeed * Time.deltaTime;
        currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);

        // 카메라 줌 인/아웃 부드럽게 처리
        Vector3 zoomDirection = transform.forward * currentZoomDistance;
        Vector3 targetZoomPosition = target.position - zoomDirection;
        transform.position = Vector3.SmoothDamp(transform.position, targetZoomPosition, ref smoothVelocity, smoothTime);

        lastMousePosition = Input.mousePosition;
    }

    private float GetPinchZoom()
    {
        if (Input.touchCount == 2)
        {
            // 모바일 터치 pinch 처리
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
            float touchDeltaMag = (touch0.position - touch1.position).magnitude;

            return prevTouchDeltaMag - touchDeltaMag;
        }
        return 0.0f;
    }
}