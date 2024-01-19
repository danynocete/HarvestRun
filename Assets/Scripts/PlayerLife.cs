using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigidBody;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    /**
     * Checks if Player is touching a fly
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if player collides with Fly object or the ground they should die
        if (collision.gameObject.CompareTag("Fly") || collision.gameObject.CompareTag("Ground")) 
        {
            PlayerDies();
        }
    }

    /**
     * Player dies and it shouldn't be able to move
     */
    private void PlayerDies()
    {
        playerAnimator.SetTrigger("Die");
        playerRigidBody.bodyType = RigidbodyType2D.Static; //make Player static
    }

    /**
     * Restarts the level
     */
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //load scene that the user is on
    }
}
