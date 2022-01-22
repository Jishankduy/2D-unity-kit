using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpPainWood : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.GetComponent<PlayerControlller>() !=null)
        {
            Debug.Log("player is dead");
            Debug.Log("Game Over..!");
        }
    }
}
