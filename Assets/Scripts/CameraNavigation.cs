using UnityEngine;

public class CameraNavigation : MonoBehaviour
{
    public Transform target; // ȸ�� �߽��� �� Ÿ�� ������Ʈ
    public float rotationSpeed = 2.0f; // ȸ�� �ӵ�
    public float zoomSpeed = 2.0f; // �� �ӵ�
    public float minZoomDistance = 2.0f; // �ּ� �� �Ÿ�
    public float maxZoomDistance = 20.0f; // �ִ� �� �Ÿ�
    public float smoothTime = 0.3f; // ������ �ð�
    public float minYAngle = -90f; // y�� ȸ�� �ּ� ����
    public float maxYAngle = 90f; // y�� ȸ�� �ִ� ����

    private float currentZoomDistance;
    private Vector3 smoothVelocity;
    private Vector3 lastMousePosition;

    private void Start()
    {
        currentZoomDistance = Mathf.Clamp(Vector3.Distance(transform.position, target.position), minZoomDistance, maxZoomDistance);
    }

    private void Update()
    {
        // ���콺 �Է� �Ǵ� ����� ��ġ �Է� ó��
        if (Input.GetMouseButton(0))
        {
            // ���콺�� Ŭ�� �巡���ϰų� ����� ��ġ �������� ó��
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
            float rotationX = deltaMousePosition.y * rotationSpeed;
            float rotationY = -deltaMousePosition.x * rotationSpeed;

            // y�� ȸ�� ���� ����
            transform.RotateAround(target.position, Vector3.up, rotationY);
            transform.RotateAround(target.position, transform.right, rotationX);

            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x = Mathf.Clamp(eulerAngles.x, minYAngle, maxYAngle);
            transform.eulerAngles = eulerAngles;
        }

        // ���콺 �� �Ǵ� ����� ��ġ pinch ó��
        float zoomInput = -Input.GetAxis("Mouse ScrollWheel") + GetPinchZoom();
        currentZoomDistance += zoomInput * zoomSpeed * Time.deltaTime;
        currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);

        // ī�޶� �� ��/�ƿ� �ε巴�� ó��
        Vector3 zoomDirection = transform.forward * currentZoomDistance;
        Vector3 targetZoomPosition = target.position - zoomDirection;
        transform.position = Vector3.SmoothDamp(transform.position, targetZoomPosition, ref smoothVelocity, smoothTime);

        lastMousePosition = Input.mousePosition;
    }

    private float GetPinchZoom()
    {
        if (Input.touchCount == 2)
        {
            // ����� ��ġ pinch ó��
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