using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnFix : MonoBehaviour
{
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        GameObject playerInstance = playerInput.gameObject;
        Transform playerOne = playerInstance.transform.Find("Player01");
        Transform playerTwo = playerInstance.transform.Find("Player02");

        if (playerInput.playerIndex == 0)
        {
            if (playerTwo != null)
            {
                playerTwo.gameObject.SetActive(false);
                Debug.Log("Player 1 joined, disabling Player02");
            }
        }
        else if (playerInput.playerIndex == 1)
        {
            if (playerOne != null)
            {
                playerOne.gameObject.SetActive(false);
                Debug.Log("Player 2 joined, disabling Player01");
            }
        }
    }
}

