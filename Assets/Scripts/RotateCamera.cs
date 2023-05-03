using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 2.0f;
    [SerializeField]
    private float rangeX = 70.0f;
    [SerializeField]
    private float rangeY = 30.0f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

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
        xRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        yRotation -= Input.GetAxis("Mouse Y") * rotationSpeed;

        xRotation = Mathf.Clamp(xRotation, -rangeX, rangeX);
        yRotation = Mathf.Clamp(yRotation, -rangeY, rangeY);


        transform.eulerAngles = new Vector3(yRotation, xRotation, 0);
        // make parent Player also rotate
        transform.parent.transform.eulerAngles = new Vector3(0, xRotation, 0);
    }
}
