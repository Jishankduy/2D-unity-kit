﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject LevelLobby;
    
    private void Awake() {
        buttonPlay.onClick.AddListener(PlayGame);
    }

    private void PlayGame() {
        //SceneManager.LoadScene(1);
        LevelLobby.SetActive(true);
    }
}
