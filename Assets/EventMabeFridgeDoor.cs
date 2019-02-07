using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMabeFridgeDoor : MonoBehaviour
{
    public CharacterDialog dialog;
    private bool inRange = false;

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if(Input.GetButtonDown("Use"))
            {
                dialog.startDialog();
            }
        }
    }
}
