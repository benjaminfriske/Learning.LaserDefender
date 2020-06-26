using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    int waypointIndex = 0;
    List<Transform> waypoints;

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        Debug.Log("here !");
        this.waveConfig = waveConfig;
        this.waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints.First().transform.position;
    }

    private void Update()
    {
        if(waveConfig != null)
        {
            Debug.Log(waypointIndex.ToString() + " : " + waypoints.Count.ToString());
            if (waypointIndex <= waypoints.Count - 1)
            {
                Debug.Log("Here!");
                var targetPosition = waypoints[waypointIndex].transform.position;
                var moveThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
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

}
