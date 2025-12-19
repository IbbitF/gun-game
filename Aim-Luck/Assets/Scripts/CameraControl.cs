using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class CameraControl : MonoBehaviour
{
    float yaw = 0f; //Left-Right
    float pitch = 0f; //Up-Down
    public float sensitivity = 2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;

        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * 10f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * 10f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.ProjectOnPlane(transform.right, Vector3.up).normalized * 10f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.ProjectOnPlane(transform.right, Vector3.up).normalized * 10f * Time.deltaTime;
        }
    }
}
