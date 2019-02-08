using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUsePrompt : MonoBehaviour
{
    public Text textPrompt;
    public bool hideAfterUse = false;
    private bool isHidden = false;
    private bool inRange = false;
    // Start is called before the first frame update

    void Start()
    {
        textPrompt.enabled = false;
    }

    private void hidePrompt()
    {
        textPrompt.enabled = false;
        isHidden = true;
    }

    private void showPrompt()
    {
        if (isHidden)
        {
            textPrompt.enabled = false;
        } else
        {
            textPrompt.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            showPrompt();
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hidePrompt();
            inRange = false;
            isHidden = false;
        }
    }
    private void Update()
    {
        if (hideAfterUse && inRange)
        {
            if (Input.GetButtonDown("Use"))
            {
                isHidden = true;
                showPrompt();
            }
        }
    }
}
