using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 2.0f;
    [SerializeField]
    private float rangeY = 70.0f;
    [SerializeField]
    private float minX = -40.0f;
    [SerializeField]
    private float maxX = 30.0f;
    private float horizontalRotation = 0;
    private float verticalRotation = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MouseRotatesCamera();
    }

    void MouseRotatesCamera()
    {
        horizontalRotation += Input.GetAxis("Mouse Y") * rotationSpeed;
        verticalRotation -= Input.GetAxis("Mouse X") * rotationSpeed;

        horizontalRotation = Mathf.Clamp(horizontalRotation, minX, maxX);
        verticalRotation = Mathf.Clamp(verticalRotation, -rangeY, rangeY);

        transform.eulerAngles = new Vector3(horizontalRotation, verticalRotation, 0);
    }
}
