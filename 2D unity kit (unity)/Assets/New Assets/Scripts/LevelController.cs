﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.GetComponent<PlayerControlller>() !=null)
        {
            Debug.Log("Level Finished by the player");
        }
        
    }
}
