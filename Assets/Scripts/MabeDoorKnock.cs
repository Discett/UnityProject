using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MabeDoorKnock : MonoBehaviour
{
    public AudioClip doorOpen;
    public AudioClip doorClose;
    private bool inRange;
    public CharacterDialog dialog;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = false;
        }
    }
    void Update()
    {
        if (inRange && Input.GetButtonDown("Use"))
        {
            dialog.startDialog();
        }
    }

    public void audioDoorOpen()
    {
        AudioSource.PlayClipAtPoint(doorOpen,transform.position);
    }
    public void audioDoorClose()
    {
        AudioSource.PlayClipAtPoint(doorClose, transform.position);
    }
}
