using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Text txtPause,txttitulo,txtplay;
    [SerializeField] private Image imgfundoplay;
    [SerializeField] private Button play;
    [SerializeField] private Button movefox;
    private void Start()
    {
        Time.timeScale = 1;
        movefox = GameObject.FindWithTag("botaomove").GetComponent<Button>();
    }
    public void Play()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            play.enabled = true;
            txttitulo.enabled = true;
            txtplay.enabled = true;
            imgfundoplay.enabled = true;
            movefox.enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            play.enabled = false;
            txttitulo.enabled = false;
            txtplay.enabled = false;
            imgfundoplay.enabled = false;
            movefox.enabled = true;
        }
    }
    public void Pausa()
    {
        if (Time.timeScale == 1) 
        {
            Time.timeScale = 0;
            txtPause.enabled = true;
        } else 
        {
            Time.timeScale = 1;
            txtPause.enabled = false;

        }
    }

}
