using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingEvent : MonoBehaviour
{

    GameManager gm;
    public GameObject playerCamera;
    public GameObject sleepCamera;
    public GameObject playerSleepingBody;
    public ShowUsePrompt prompt;
    public CharacterDialog dialog;
    public Animator sleepAnimator;
    public Light bedroomLight;
    public Animator doorAnimator;
    public Animator visitor;
    public CharacterDialog visitorDialog;
    bool inRange = false;

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
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void startVisitorDialog()
    {
        visitorDialog.startDialog();
    }
    public void visitorEvent()
    {
        doorAnimator.SetTrigger("visitor");
        visitor.SetTrigger("start");
        Invoke("startVisitorDialog",2f);
    }

    void Update()
    {
        if(inRange && Input.GetButtonDown("Use"))
        {
            if (gm.getMosiahSelanieGreeting())
            {
                prompt.setPromptText("");
                playerCamera.SetActive(false);
                playerSleepingBody.SetActive(true);
                bedroomLight.enabled = false;
                doorAnimator.SetBool("open", false);
                sleepCamera.SetActive(true);
                sleepAnimator.SetTrigger("look");
                Invoke("visitorEvent", 1.5f);
            } else
            {
                dialog.startDialog();
            }
        }
    }
}
