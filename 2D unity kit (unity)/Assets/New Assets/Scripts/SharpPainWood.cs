using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SharpPainWood : MonoBehaviour
{
    public GameOverController gameOverController;
    public PlayerControlller playerController;
    private void OnTriggerEnter2D(Collider2D collision) {
        
         if(collision.gameObject.GetComponent<PlayerControlller>() !=null)
        {
            StartCoroutine(DeathScene());
        }

         IEnumerator DeathScene()
        {
            playerController.animator.SetTrigger("Death");
            yield return new WaitForSeconds(0.8f);
            gameOverController.PlayerDied();
        }
        
    }
}
