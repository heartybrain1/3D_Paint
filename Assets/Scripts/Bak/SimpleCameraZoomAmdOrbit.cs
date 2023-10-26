using UnityEngine;

public class SimpleCameraZoomAmdOrbit : MonoBehaviour
{
    public Transform target; // Ÿ�� ������Ʈ
    public float distance = 5.0f; // ī�޶�� Ÿ�� ���� �Ÿ�
    public float sensitivity = 2.0f; // ���콺 ȸ�� ����
    public float zoomSpeed = 2.0f; // Ȯ�� �� ��� �ӵ�
    public float minDistance = 2.0f; // �ּ� �Ÿ�
    public float maxDistance = 10.0f; // �ִ� �Ÿ�

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
        // ���콺 ȸ��
        if (Input.GetMouseButton(0)) // ���콺 ���� ��ư Ŭ�� ��
        {
            xRotation += Input.GetAxis("Mouse X") * sensitivity;
            yRotation -= Input.GetAxis("Mouse Y") * sensitivity;
            yRotation = Mathf.Clamp(yRotation, -90, 90); // ��/�Ʒ��� �ʹ� ȸ������ �ʵ��� ����
        }


        // ����� ��ġ ȸ�� (Swipe)
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

        // Ȯ�� �� ���
        currentDistance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        // �ּ� �� �ִ� �Ÿ� ����
        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

        // ī�޶� ��ġ ���
        Vector3 dir = new Vector3(0, 0, -currentDistance);
        Quaternion rotation = Quaternion.Euler(yRotation, xRotation, 0);
        transform.position = target.position + rotation * dir;
        transform.LookAt(target.position);



    }
}