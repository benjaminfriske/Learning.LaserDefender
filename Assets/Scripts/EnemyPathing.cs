using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;

    int waypointIndex = 0;


    private void Start()
    {
        transform.position = waypoints.First().transform.position;
    }

    private void Update()
    {
        Debug.Log(waypointIndex.ToString() + " : " + waypoints.Count.ToString());
        if (waypointIndex <= waypoints.Count - 1)
        {
            Debug.Log("Here!");
            var targetPosition = waypoints[waypointIndex].transform.position;
            var moveThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
