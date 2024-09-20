using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    int index = 0;
    PlayerInputManager manager;

    public List<GameObject> players = new List<GameObject>();

    private void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = players[index];
    }

    public void SwitchNextSpawnCharacter(PlayerInput input)
    {
        index = (index + 1) % players.Count;
        manager.playerPrefab = players[index];
    }
}
