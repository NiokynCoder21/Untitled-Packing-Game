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

    public void Retry()
    {
        Destroy(canvas);
        SceneManager.LoadScene("OutHouse", LoadSceneMode.Single); // Load Player 1 win scene
    }
}
