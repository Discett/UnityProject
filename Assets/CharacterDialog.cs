using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterDialog : MonoBehaviour
{
    private Text text;
    public PlayerMovementCC player;
    public MouseLook playerMouse;
    public TextAsset dialog;
    public Text nameTag;
    public Canvas canvas;
    public Animator NPC;
    string[] linesInFile;
    private int counter = 0;
    public bool interacted = false;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        //playerMouse.enabled = false;
        //player.enabled = false;
        linesInFile = dialog.text.Split('\n');
        canvas.enabled = false;
    }

    public void playerInteracted()
    {
        interacted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (interacted)
        {
            
            if (linesInFile.Length > counter)
            {
                canvas.enabled = true;
                player.enabled = false;
                playerMouse.enabled = false;
                if (linesInFile[counter].Contains("//"))
                {
                    nameTag.text = linesInFile[counter].Substring(2);
                    counter++;
                }
                else
                {
                    text.text = linesInFile[counter];
                }
                if (Input.anyKeyDown)
                {
                    counter++;
                }
            }
            else
            {
                NPC.SetBool("isTalking", false);
                canvas.enabled = false;
                player.enabled = true;
                playerMouse.enabled = true;
            }
        }
    }
    
}
