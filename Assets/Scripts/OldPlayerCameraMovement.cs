using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    Vector2 rotation = new Vector2(0, 0);
    public int maxLookHeight = 24;
    public float speed = 3;

    void FixedUpdate()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        if(rotation.x > maxLookHeight)
        {
            rotation.x = maxLookHeight;
        } else if (rotation.x < -maxLookHeight)
        {
            rotation.x = -maxLookHeight;
        }
        transform.eulerAngles = (Vector2)rotation * speed;
    }

}
