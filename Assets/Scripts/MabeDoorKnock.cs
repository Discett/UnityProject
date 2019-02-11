using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MabeDoorKnock : MonoBehaviour
{

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
}
