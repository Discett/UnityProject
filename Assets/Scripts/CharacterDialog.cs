using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterDialog : MonoBehaviour
{
    //This is for the dialogBox image
    public Image imageBox;
    //This is for displaying dialog
    public Text dialogText;
    //This is for displayer who is talking
    public Text nameTag;
    //This is for the file for what is going to be said
    public TextAsset dialogScript;
    //We want to influence the player when in a dialog so we can set options
    public PlayerMovementCC player;
    public MouseLook playerMouse;
    public Transform focusObject;
    public AudioClip speaking;
    public bool repeatable = false;
    public float focusSpeed = 20f;

    string[] linesInFile;
    private int counter = 0;
    public bool dialogInitiated = false;
    private bool dialogFinished = false;

    void Start()
    {
        linesInFile = dialogScript.text.Split('\n');
        imageBox.enabled = false;
        dialogText.enabled = false;
        nameTag.enabled = false;
    }

    public void startDialog()
    {
        dialogFinished = false;
        dialogInitiated = true;
    }

    public void stopDialog()
    {
        dialogInitiated = false;
    }

    public bool isDialogFinished()
    {
        return dialogFinished;
    }

    public void setFocusObject(Transform focus)
    {
        focusObject = focus;
    }

    public void onSpeak()
    {
        AudioSource.PlayClipAtPoint(speaking,transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogInitiated)
        {
            if (linesInFile.Length > counter)
            {
                imageBox.enabled = true;
                dialogText.enabled = true;
                nameTag.enabled = true;
                player.enabled = false;
                playerMouse.disableLook();
                if (focusObject)
                {
                    playerMouse.setFocus(focusObject);
                    playerMouse.startFocus();
                }

                if (linesInFile[counter].Contains("//"))
                {
                    nameTag.text = linesInFile[counter].Substring(2);
                    counter++;
                }
                else
                {
                    dialogText.text = linesInFile[counter];
                }
                //Change this to enter or something later
                if (Input.GetButtonDown("Submit"))
                {
                    counter++;
                }
            }
            else
            {
                imageBox.enabled = false;
                nameTag.enabled = false;
                dialogText.enabled = false;
                player.enabled = true;
                playerMouse.enableLook();
                dialogInitiated = false;
                dialogFinished = true;
                playerMouse.stopFocus();
                if (repeatable)
                {
                    counter = 0;
                }
            }
        }
    }
    
}
