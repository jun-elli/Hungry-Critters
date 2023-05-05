using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform playerBody;

    [SerializeField]
    private float rotationSpeed = 100.0f;

    [SerializeField]
    private float rangeY = 30.0f;
    private float xRotation = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseRotatesCamera();
    }

    void MouseRotatesCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -rangeY, rangeY);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        // we rotate all player gameobject
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
