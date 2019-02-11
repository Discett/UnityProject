using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool haunting = false;
    public bool mabeSleep = false;
    public bool mosiahSelanieGreeting = false;

    public bool isHaunting()
    {
        return haunting;
    }

    public bool isMabeSleep()
    {
        return mabeSleep;
    }

    public void triggeredMabeSleep()
    {
        mabeSleep = true;
    }

    public void triggeredHaunting()
    {
        haunting = true;
    }

    public void triggeredMosiahSelanieGreeting()
    {
        mosiahSelanieGreeting = true;
    }

    public bool getHaunting()
    {
        return haunting;
    }
    public bool getMabeSleep()
    {
        return mabeSleep;
    }
    public bool getMosiahSelanieGreeting()
    {
        return mosiahSelanieGreeting;
    }
}
