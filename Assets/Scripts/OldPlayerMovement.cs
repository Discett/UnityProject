using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform player;
    public float PlayerMoveSpeed  = 10f;
    public float PlayerStrafeSpeed = 10f;
    public float playerGravity = 2f;
    public Transform cam;


    // Update is called once per frame
    void FixedUpdate()
    {
        float camYAngle = cam.eulerAngles.y;
        transform.localEulerAngles = new Vector3(0, camYAngle, 0);
        rb.AddForce(0,-playerGravity,0,ForceMode.VelocityChange);

       
        if (Input.GetKey("w"))
        {

            float x = 0;
            float z = 0;
            z = Mathf.Cos((camYAngle * Mathf.PI) / 180) * PlayerMoveSpeed;
            x = Mathf.Sin((camYAngle * Mathf.PI) / 180) * PlayerMoveSpeed;
            rb.AddForce(x, 0, z, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {

            float x = 0;
            float z = 0;
            z = Mathf.Cos((camYAngle * Mathf.PI) / 180) * PlayerMoveSpeed;
            x = Mathf.Sin((camYAngle * Mathf.PI) / 180) * PlayerMoveSpeed;
            rb.AddForce(-x, 0, -z, ForceMode.VelocityChange);

        }
        if (Input.GetKey("a"))
        {

            float x = 0;
            float z = 0;
            z = Mathf.Cos(((camYAngle - 90) * Mathf.PI) / 180) * PlayerStrafeSpeed;
            x = Mathf.Sin(((camYAngle - 90) * Mathf.PI) / 180) * PlayerStrafeSpeed;
            rb.AddForce(x, 0, z, ForceMode.VelocityChange);

        }
        if (Input.GetKey("d"))
        {

            float x = 0;
            float z = 0;
            z = Mathf.Cos(((90 + camYAngle) * Mathf.PI) / 180) * PlayerStrafeSpeed;
            x = Mathf.Sin(((90 + camYAngle) * Mathf.PI) / 180) * PlayerStrafeSpeed;
            rb.AddForce(x, 0, z, ForceMode.VelocityChange);

        }
        if (Input.GetKey("space"))
        {
            // do I even want to jump?
        }
        if (Input.GetKey("e"))
        {

        }
    }
}
