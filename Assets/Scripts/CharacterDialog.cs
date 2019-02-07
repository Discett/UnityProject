﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterDialog : MonoBehaviour
{
    //This is for displaying dialog
    public Text text;
    //This is for displayer who is talking
    public Text nameTag;
    //This is for the file for what is going to be said
    public TextAsset dialog;
    //We want to influence the player when in a dialog so we can set options
    public PlayerMovementCC player;
    public MouseLook playerMouse;
    public Transform focusObject;
    public bool repeatable = false;

    public Canvas canvas;
    string[] linesInFile;
    private int counter = 0;
    public bool dialogInitiated = false;
    private bool dialogFinished = false;

    void Start()
    {
        linesInFile = dialog.text.Split('\n');
        canvas.enabled = false;
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

    // Update is called once per frame
    void Update()
    {
        if (dialogInitiated)
        {
            if (linesInFile.Length > counter)
            {
                canvas.enabled = true;
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
                    text.text = linesInFile[counter];
                }
                //Change this to enter or something later
                if (Input.GetButtonDown("Submit"))
                {
                    counter++;
                }
            }
            else
            {
                canvas.enabled = false;
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
