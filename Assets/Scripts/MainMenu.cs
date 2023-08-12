// Code From Brackeys

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame ()
    {
        SceneManager.LoadScene("NaPuaHoku");
    }

    public void QuitGame () 
    {
        UnityEngine.Debug.Log("QUIT!");
        Application.Quit();
    }

}
