using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenDoor : MonoBehaviour
{
    public AudioClip doorOpen;
    public AudioClip doorClose;
    bool open = false;
    bool inRange = false;
    private Animator animator;

    public void audioPlayOpen()
    {
        AudioSource.PlayClipAtPoint(doorOpen,transform.position);
    }

    public void audioPlayClose()
    {
        AudioSource.PlayClipAtPoint(doorClose, transform.position);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

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
