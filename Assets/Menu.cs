using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button start;
    public Button quit;
    // Start is called before the first frame update

    void Start()
    {
        start.onClick.AddListener(onStart);
        quit.onClick.AddListener(onQuit);
    }

    void onStart()
    {
        SceneManager.LoadScene("ApartmentHallway", LoadSceneMode.Single);
    }
    void onQuit()
    {
        Application.Quit();
    }
}
