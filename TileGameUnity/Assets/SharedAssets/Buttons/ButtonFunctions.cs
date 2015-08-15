using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour 
{
    public void GoToMainMenu()
    {
        Application.LoadLevel("MenuScene"); 
    }	

    public void ExitGame()
    {
        Application.Quit();
    }
}

