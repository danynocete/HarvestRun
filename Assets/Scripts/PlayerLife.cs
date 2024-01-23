using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigidBody;

    private int heartIndex = 2;

    [SerializeField] private List<GameObject> hearts; //array of Heart Objects

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
        //if player collides with Fly object or the thorns they should and lose a life
        if (collision.gameObject.CompareTag("Fly")|| collision.gameObject.CompareTag("Trap"))
        {
            //if current lives > 0 restart level
            if(hearts.Count > 0)
            {
                Destroy(hearts[heartIndex]);
                hearts.RemoveAt(heartIndex);
                heartIndex = heartIndex - 1;
                Debug.Log("hearts list: " + hearts.Count);
            }
            //if current lives <0 game ends
            if(hearts.Count < 1)
            {
                PlayerDies();
                //load Game Over scene
            }
        }
        //if Player falls to the ground they instantly die
        if (collision.gameObject.CompareTag("Ground"))
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
