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
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource hitSound;

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
        //if player collides with Fly object or red worms they should lose a life
        if (collision.gameObject.CompareTag("Fly") || collision.gameObject.CompareTag("Worm"))
        {
            //if current lives > 0 restart level
            if(hearts.Count > 0)
            {
                hitSound.Play();
                Destroy(hearts[heartIndex]);
                hearts.RemoveAt(heartIndex);
                heartIndex = heartIndex - 1;
            }
            //if current lives <0 game ends
            if(hearts.Count < 1)
            {
                PlayerDies();
                //load Game Over scene
            }
        }
        //if Player falls to the ground or touch the thorns they instantly die
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Trap"))
        {
            PlayerDies();
        }
    }

    /**
     * Player dies and it shouldn't be able to move
     */
    private void PlayerDies()
    {
        deathSound.Play();
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
