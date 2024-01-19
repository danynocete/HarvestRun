using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; //array of waypoints
    [SerializeField] private float speed = 2f;
    private SpriteRenderer fly; //render for fly object

    private int currentWaypointIndex = 0;

    private void Start()
    {
            fly = GetComponent<SpriteRenderer>();
      
    }
    private  void Update()
    {
        Vector2 currentWaypointPos = waypoints[currentWaypointIndex].transform.position;
        float distance = Time.deltaTime * speed; //distance the platform will move in one frame

        //if the moving platform is in the same position as the current waypoint move platform to next waypoint
        if (Vector2.Distance(currentWaypointPos, transform.position) < .1f)
        {
            currentWaypointIndex++;
            fly.flipX = false; 
            //if current waypoint is the last one in the array go back to the first waypoint
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
                fly.flipX = true; //flip fly object when going back to the starting waypoint
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, currentWaypointPos, distance); //move the platform
    }
}
