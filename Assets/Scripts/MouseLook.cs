using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float MouseSensitivity = 2f;
    [SerializeField] Transform playerCamera;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * MouseSensitivity;
        float mousey = Input.GetAxis("Mouse Y") * MouseSensitivity;

        transform.Rotate(Vector3.up * mousex);
        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    void LateUpdate()
    {
        playerCamera.localRotation =
                Quaternion.Euler(xRotation, 0f, 0f);
    }
}

