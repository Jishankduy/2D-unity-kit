using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D Collision) {
        PlayerControlller PlayerControlller = Collision.gameObject.GetComponent<PlayerControlller>();
        PlayerControlller.PickUpKey();
        Destroy(gameObject);
    
    }
}
