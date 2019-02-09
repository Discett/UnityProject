using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MabeBedEvent : MonoBehaviour
{
    public Animator door;
    public CharacterDialog dialog;
    private Animator mabe;

    private void Start()
    {
        mabe = GetComponent<Animator>();
        dialog.startDialog();
    }

    public void unlockMabeDoor()
    {
        door.SetBool("open", true);
    }

    public void lockMabeDoor()
    {
        door.SetBool("open", false);
    }

    private void Update()
    {
        if (dialog.isDialogFinished())
        {
            mabe.SetBool("isTalking", false);
        }
    }
}
