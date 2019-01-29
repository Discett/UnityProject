using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MabeMeetingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator door;
    private Animator NPC;
    private BoxCollider trigger;
    public CharacterDialog dialog;
    private bool inRange = false;
    public void openDoor()
    {
        door.SetBool("open", true);
    }
    void Start()
    {
        trigger = this.GetComponent<BoxCollider>();
        NPC = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e") && inRange)
        {
            NPC.SetBool("interacted", true);
            dialog.playerInteracted();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        inRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }
}
