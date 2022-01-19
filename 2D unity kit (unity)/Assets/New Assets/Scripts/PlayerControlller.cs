using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
   public Animator animator;
   public float speed;
   public float Jump;
   private Rigidbody2D rb2D;

    
    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);
    }

    private void MoveCharacter(float horizontal, float vertical){
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        if(vertical > 0){
           rb2D.AddForce(new Vector2(0f,Jump), ForceMode2D.Force); 
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical) {
        animator.SetFloat("Speed",Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0) {
            scale.x = -1f * Mathf.Abs(scale.x);
        } else if(horizontal > 0) {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump
       
        if (Input.GetButtonDown("Jump")) {
            animator.SetTrigger("jump");
        };

        //Crourch

        if (Input.GetButtonDown("Fire1")) {
            animator.SetTrigger("Crourch");
        };

        // // Run
        // if (Input.GetButtonDown("Fire3 > ")) {
        //     animator.SetBool("Run", true);
        // }

        // else (Input.GetButtonDown("Fire3"))
        // {
        //     animator.SetBool("Run", false);
        // }
        

    }
    
    
}
