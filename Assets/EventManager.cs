using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public MosiahSelanieMeeting mosiahSelanieMeeting;
    public bool testBool = false;

    void startMosiahSelanieMeeting()
    {
        if (!FindObjectOfType<GameManager>().getMosiahSelanieGreeting())
        {
            mosiahSelanieMeeting.enabled = true;
        } else
        {
            mosiahSelanieMeeting.enabled = false;
        }
    }


    private void Start()
    {
        Invoke("startMosiahSelanieMeeting", 120f);
    }

}
