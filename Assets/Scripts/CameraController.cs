using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform target; // 카메라의 타겟 오브젝트
    public float distance = 5.0f; // 카메라와 타겟 간의 거리
    public float minDistance = 2.0f; // 최소 거리
    public float maxDistance = 10.0f; // 최대 거리
    public float rotationSmoothness = 5.0f; // 회전 보간값
    public float zoomSpeed = 2.0f; // 확대 및 축소 속도

    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    private void Update()
    {
        // 회전
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        xRotation += mouseX * rotationSmoothness;
        yRotation -= mouseY * rotationSmoothness;
        yRotation = Mathf.Clamp(yRotation, -90, 90);

        // 확대 및 축소
        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // 보간된 회전 및 위치 설정
        Quaternion targetRotation = Quaternion.Euler(yRotation, xRotation, 0);
        Vector3 targetPosition = target.position - (targetRotation * Vector3.forward * distance);

        // 부드러운 회전 및 이동 적용
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmoothness);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * rotationSmoothness);
    }
}