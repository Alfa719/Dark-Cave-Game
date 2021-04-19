using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, kontenHelp;
    void Start()
    {
        mainMenu.SetActive(true);
        kontenHelp.SetActive(false);
    }
    void Update()
    {
        
    }
    public void PlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Gameplay");
    }
    public void HelpButton()
    {
        mainMenu.SetActive(false);
        kontenHelp.SetActive(true);
    }
    public void BackToMainMenuButton()
    {
        mainMenu.SetActive(true);
        kontenHelp.SetActive(false);
    }
    public void ExitButton()
    {
        Debug.Log("Keluar dari aplikasi");
        Application.Quit();
    }
}
