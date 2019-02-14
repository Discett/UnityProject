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
                sleepCamera.SetActive(true);
                sleepAnimator.SetTrigger("look");
                //Character Event
                Debug.Log("EventCharacterHere");
            } else
            {
                dialog.startDialog();
            }
        }
    }
}
