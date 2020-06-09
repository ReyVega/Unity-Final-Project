using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    public Transform cameraFollowObj;

    public static float mouseX,
                 mouseY,
                 rotY = 0.0f,
                 rotX = 0.0f,
                 finalInputX,
                 finalInputZ,
                 inputSensitivity = 150.0f,
                 clampAngle = 80.0f,
                 cameraMoveSpeed = 120.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update()
    {
        //Rotación de cámara
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        finalInputX = inputX + mouseX;
        finalInputZ = inputX + mouseY;

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX -= finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.cameraUpdater();
    }

    void cameraUpdater() {
        Transform target = this.cameraFollowObj.transform;

        float step = cameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,target.position,step);
    }
}
