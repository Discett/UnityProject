using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventMabeFridgeDoor : MonoBehaviour
{
    public CharacterDialog dialog;
    private bool inRange = false;



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
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
    private void startDialog()
    {
        dialog.startDialog();
    }
    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if(Input.GetButtonDown("Use"))
            {
                Invoke("startDialog", 2f);
            }
        }
    }
}
