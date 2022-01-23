using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cellingoptical : MonoBehaviour
{
    public PlayerControlller playerController;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerControlller>() != null)
        {
            StartCoroutine(DeathScene());
        }

        IEnumerator DeathScene()
        {
            playerController.animator.SetTrigger("Death");
            yield return new WaitForSeconds(0.8f);
            Reloadlevel();
        }


        void Reloadlevel()
        {
            SceneManager.LoadScene(0);
        }

    }
}
