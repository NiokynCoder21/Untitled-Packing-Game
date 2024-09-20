using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject canvas;
    public void onRetry(InputAction.CallbackContext context)
    {
        Retry();
    }

    public void onStart(InputAction.CallbackContext context)
    {
        StartGame();
    }

    public void onQuit(InputAction.CallbackContext context)
    {
        QuitGame();
    }

    public void onContinue(InputAction.CallbackContext context)
    {
        ContinueGame();
    }

    public void onMainMenu(InputAction.CallbackContext context)
    {
        MainMenuGame();
    }

    public void Retry()
    {
        Destroy(canvas);
        SceneManager.LoadScene("OutHouse", LoadSceneMode.Single); // Load Player 1 win scene
    }

    public void StartGame()
    {
        SceneManager.LoadScene("IntroScence", LoadSceneMode.Single); // Load Player 1 win scene
    }

    public void ContinueGame()
    {
        Destroy(canvas);
        SceneManager.LoadScene("OutHouse", LoadSceneMode.Single); // Load Player 1 win scene
    }

    public void MainMenuGame()
    {
        Destroy(canvas);
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single); // Load Player 1 win scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
