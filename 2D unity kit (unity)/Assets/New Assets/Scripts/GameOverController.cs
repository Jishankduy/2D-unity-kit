﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestast;

    private void Awake(){
        buttonRestast.onClick.AddListener(Reloadlevel);
    }

    public void PlayerDied(){
        gameObject.SetActive(true);
    }

    void Reloadlevel(){
            Debug.Log("Reloading Scene 0");
            SceneManager.LoadScene(0);
        }
}
