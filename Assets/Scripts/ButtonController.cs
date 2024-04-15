using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void ExitButton(){
        Application.Quit();
    }

    public void StartGame(){
        SceneManager.LoadScene("cenaBase");
    }
    public void MainMenu(){
        SceneManager.LoadScene("mainMenu");
    }
}
