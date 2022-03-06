using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Cena1");
    }
    public void PlayGame2()
    {
        SceneManager.LoadScene("Cena2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
