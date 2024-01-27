using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    /**
     * Starts game
     */
    public void StartGame()
    {
        SceneManager.LoadScene(1); //load level 1
    }
}
