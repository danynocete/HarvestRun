using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4f; //speed for left and right movement
    private float xDirection = 0f; //Player's x direction
    private float jumpSpeed = 5f;
    [SerializeField] private LayerMask ground;

    private Rigidbody2D playerRigidBody; //the Player object rigidBody
    private Animator playerAnimator; //the Player's Animator
    private SpriteRenderer sprite;
    private BoxCollider2D playerBoxCollider;


    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
    }
    
    private void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");
        playerRigidBody.velocity = new Vector2(xDirection * speed, playerRigidBody.velocity.y); //Player's velocity

        //if jump is pressed and Player is on terrain - jump 
        if (Input.GetButtonDown("Jump") && OnTerrain())
        {
            playerRigidBody.velocity = new Vector3(0, jumpSpeed,0);
        }
        SetAnimation();
    }

    /**
     * Check if Player is on terrain
     */
    private bool OnTerrain()
    {
        
        return Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.size, 0f, Vector2.down, .1f, ground);
    }

    /**
     * Sets the correct animation for the Player
     */
    private void SetAnimation()
    {
        // left animation if x is less than 0
        if(xDirection < 0)
        {
            playerAnimator.SetBool("Running", true);
            sprite.flipX = true; //flip sprite facing left
        }
        //right animation if x > 0
        else if(xDirection > 0)
        {
            playerAnimator.SetBool("Running", true);
            sprite.flipX = false; //flip sprite facing left
        }
        //idle animation if x = 0
        else
        {
            playerAnimator.SetBool("Running", false);
        }
    }

}
