using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {
    // Use this for initialization

    public void Start_Game()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
