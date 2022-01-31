using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFinishController : MonoBehaviour
{
    public Button buttonRestast;

    private void Awake(){
        buttonRestast.onClick.AddListener(Reloadlevel);
    }

    public void PlayerWin(){
        gameObject.SetActive(true);
    }

    void Reloadlevel(){
            Debug.Log("Reloading Scene ");
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }
}
