using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private GameObject player;
    int itemsCollected = 0;
    int totalMushrooms = 0;
    private ItemCollector itemCollector; //reference to ItemCOllector script

   // Start is called before the first frame update
   private void Start()
    {
        itemCollector = GetComponent<ItemCollector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        itemsCollected = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemCollector>().getMushroomsCollected(); //number of items the PLayer has collected
        totalMushrooms = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemCollector>().totalMushrooms(); //number of mushrooms the Player needs to collect
        Debug.Log("Items collected: " + itemsCollected);

        //if the Player touches finish flag and has collected all items the game finishes
        if(collision.gameObject.name == "Player" && itemsCollected == totalMushrooms)
        {
            Debug.Log("You win!");
            
            LoadEndGameScene();
        }
        else if(collision.gameObject.name == "Player" && itemsCollected != totalMushrooms)
        {
            Debug.Log("Need to collect more items");
        }
    }

    /**
     * Loads the endgame scene
     */
    private void LoadEndGameScene()
    {
        SceneManager.LoadScene(2); //load endgame scene
    }
}
