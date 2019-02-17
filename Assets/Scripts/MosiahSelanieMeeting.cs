using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosiahSelanieMeeting : MonoBehaviour
{
    // Start is called before the first frame update
    private bool inRange;
    public CharacterDialog dialogMosiah;
    public CharacterDialog dialogSelanie;
    public ShowUsePrompt prompt;
    public Animator mosiah;
    public Animator selanie;
    public Animator door;
    public AudioClip audioDoorSlam;
    public AudioClip audioDoorOpen;
    public AudioClip mosiahSpeak;
    public AudioClip selanieSpeak;
    public AudioSource knocking;
    public string promptText = "Press \"Use\" to answer the door";
    private bool mosiahFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
    void playAudioDoorOpen()
    {
        AudioSource.PlayClipAtPoint(audioDoorOpen, door.targetPosition);
    }
    private void MosiahTalk()
    {
        mosiah.SetBool("isTalking", true);
        AudioSource.PlayClipAtPoint(mosiahSpeak,mosiah.targetPosition);
        dialogMosiah.startDialog();
    }

    private void SelanieTalk()
    {
        selanie.SetBool("isTalking", true);
        AudioSource.PlayClipAtPoint(selanieSpeak, selanie.targetPosition);
        dialogSelanie.startDialog();
    }
    private void characterExit()
    {
        mosiah.SetBool("isTalking", false);
        selanie.SetBool("isTalking", false);
    }
    private void Start()
    {
        knocking.Play();
    }
    void Update()
    {
        if(inRange && !FindObjectOfType<GameManager>().getMosiahSelanieGreeting())
        {
            prompt.setPromptText(promptText);
        } 

        if (inRange && Input.GetButtonDown("Use"))
        {
            knocking.Stop();
            prompt.setPromptText("");
            mosiah.SetBool("Mosiah&SelanieMeeting", true);
            selanie.SetBool("Mosiah&SelanieMeeting", true);
            door.SetBool("open", true);
            Invoke("MosiahTalk", 1f);
        }

        if (dialogMosiah.isDialogFinished() && !mosiahFinished)
        {
            Invoke("SelanieTalk", .5f);
            mosiahFinished = true;
        }

        if (dialogSelanie.isDialogFinished())
        {
            FindObjectOfType<GameManager>().triggeredMosiahSelanieGreeting();
            AudioSource.PlayClipAtPoint(audioDoorSlam,door.targetPosition);
            door.SetBool("open", false);
            Invoke("characterExit", 120f);
            this.enabled = false;
            prompt.setPromptText("");
        }

    }
}
