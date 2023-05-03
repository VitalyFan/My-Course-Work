using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Move : MonoBehaviour
{
    float xRot;
    float yRot;
    float xRotCurrent;
    float yRotCurrent;
    float currentVelocityX;
    float currentVelocityY;
    public Camera player;
    public GameObject playerGameObject;
    public float smoothTime = 0.1f;
    public float sensivity = 5f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }

        if (Input.GetKey(KeyCode.Mouse2))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }

        MouseMove();
        
    }

    void MouseMove()
    {
        xRot += Input.GetAxis("Mouse X") * sensivity;
        yRot += Input.GetAxis("Mouse Y") * sensivity;

        yRot = Mathf.Clamp(yRot, -90, 90);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRot, ref currentVelocityX, smoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRot, ref currentVelocityY, smoothTime);

        player.transform.rotation = Quaternion.Euler(-yRotCurrent, xRotCurrent, 0f);
        playerGameObject.transform.rotation = Quaternion.Euler(0f, xRotCurrent, 0f);
    }
}
