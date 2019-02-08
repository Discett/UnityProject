using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenDoor : MonoBehaviour
{
    bool open = false;
    bool inRange = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(USEKEY))
            {
                if (!open)
                {
                    animator.SetBool("open", true);
                    open = true;
                }
                else
                {
                    animator.SetBool("open", false);
                    open = false;
                }
            }
            
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetButtonDown("Use"))
            {
                if (!open)
                {
                    animator.SetBool("open", true);
                    open = true;
                }
                else
                {
                    animator.SetBool("open", false);
                    open = false;
                }
            }
        }
    }

}
