using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private List<GameObject> mushrooms;
    [SerializeField] private Text mushroomCounter;

    private int mushroomsCollected = 0;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if Player collides with a mushroom add it to items collected and make it disappear
        if (collision.gameObject.CompareTag("Mushroom"))
        {
            Destroy(collision.gameObject);
            mushroomsCollected++;
            mushroomCounter.text = "Mushrooms Collected: " + mushroomsCollected + "/" + mushrooms.Count;

        }
    }
}
