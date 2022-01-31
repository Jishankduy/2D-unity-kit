using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControlller : MonoBehaviour
{
    public ScoreController scoreController;
   public Animator animator;
   public float speed;
   public float Jump;
   private Rigidbody2D rb2D;
   bool isGroundCheck;
   public Transform GraundCheck;
   public LayerMask GraundLayer;
   private bool DoubleJump;
   public CapsuleCollider2D Player;

   [SerializeField]private AudioSource JumpSoundUp;

    
    private void Awake()
    {

        rb2D = gameObject.GetComponent<Rigidbody2D>();
        Player.GetComponent<CapsuleCollider2D>();
        
    }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);

    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        isGroundCheck = Physics2D.OverlapCircle(GraundCheck.position,0.2f,GraundLayer);

        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);

        if (Input.GetKeyDown("s")){

            //CrouchCollider();
            Player.size = new Vector3 (0.4885478f,1,0);
            Player.offset = new Vector3(0.0f,0.5f,0);
            animator.SetBool("CrourchDown", true);

        }

        if (Input.GetKeyUp("s")) 
        {
            Player.size = new Vector3 (0.4885478f,2.0268663f,0);
            Player.offset = new Vector3(0.01128936f,0.9971762f,0);
            animator.SetBool("CrourchDown", false);
        }
    }

    private void MoveCharacter(float horizontal, float vertical){
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;


        //Jump
        //if(vertical > 0){

          //  if (Input.GetKeyDown(KeyCode.Space) && isGroundCheck) {
            //    rb2D.AddForce(new Vector2(0f,Jump), ForceMode2D.Impulse);
              //  isGroundCheck = false;
                //DoubleJump = true;
           // }
            //else if (DoubleJump){
              //  DoubleJump =false;

            //}  
       // }
       if (Input.GetKeyDown(KeyCode.Space)){
           if (isGroundCheck){
               JumpUP();
               DoubleJump = true;
               JumpSoundUp.Play();
           }
           else if (DoubleJump){
               JumpUP();
               DoubleJump = false;
           }
       }
    }

    // Jump
    void JumpUP(){
        rb2D.velocity = Vector2.up * Jump;
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
            if (isGroundCheck){
                animator.SetTrigger("jump");
            }
           // animator.SetTrigger("jump");
            rb2D.AddForce(new Vector2(0f,Jump), ForceMode2D.Force);
        }

        //Crourch

        if (Input.GetKeyDown("s")) {
            animator.SetTrigger("Crourch");
        }

         //Run
         if (Input.GetButtonDown("Fire3")) {
            animator.SetBool("Run", true);
         }

        else if(Input.GetButtonUp("Fire3")) {
             animator.SetBool("Run", false); 
        };

    }
    
    
}
