using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform target; // ī�޶��� Ÿ�� ������Ʈ
    public float distance = 5.0f; // ī�޶�� Ÿ�� ���� �Ÿ�
    public float minDistance = 2.0f; // �ּ� �Ÿ�
    public float maxDistance = 10.0f; // �ִ� �Ÿ�
    public float rotationSmoothness = 5.0f; // ȸ�� ������
    public float zoomSpeed = 2.0f; // Ȯ�� �� ��� �ӵ�

    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    private void Update()
    {
        // ȸ��
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        xRotation += mouseX * rotationSmoothness;
        yRotation -= mouseY * rotationSmoothness;
        yRotation = Mathf.Clamp(yRotation, -90, 90);

        // Ȯ�� �� ���
        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // ������ ȸ�� �� ��ġ ����
        Quaternion targetRotation = Quaternion.Euler(yRotation, xRotation, 0);
        Vector3 targetPosition = target.position - (targetRotation * Vector3.forward * distance);

        // �ε巯�� ȸ�� �� �̵� ����
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmoothness);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * rotationSmoothness);
    }
}