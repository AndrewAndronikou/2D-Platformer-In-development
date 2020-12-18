using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] SceneFader sceneFader;
    [SerializeField] string menuSceneName = "MainMenu";
    [SerializeField] GameObject toggleUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            toggleUI.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            toggleUI.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    public void Retry()
    {
        Toggle();
        Debug.Log("Retry");
        //sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        Debug.Log("Go to Menu");
       // sceneFader.FadeTo(menuSceneName);
    }
}
