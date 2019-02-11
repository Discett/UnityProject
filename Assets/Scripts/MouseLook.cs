using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    public Transform player;
    public Transform Focus;
    public float focusSpeed = 20f;
    private bool isFocused = false;
    public bool canLook = true;

    public void enableLook()
    {
        canLook = true;
    }
    public void disableLook()
    {
        canLook = false;
    }
    public void setFocus(Transform focus)
    {
        Focus = focus;
    }
    public void startFocus()
    {
        isFocused = true;
    }
    public void stopFocus()
    {
        isFocused = false;
    }
    public void setFocusSpeed(float x)
    {
        focusSpeed = x;
    }

    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (canLook)
        {
            //player.transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y, 0);
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }
        if (isFocused)
        {
            //transform.LookAt(Focus);
            Vector3 targetDir = Focus.position - transform.position;
            float step = focusSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);

        }
    }
}
