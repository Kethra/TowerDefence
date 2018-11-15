using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    // Static Variable that references the script
    public static WayPointManager Instance;
    // List of stored Paths
    public List<Path> Paths = new List<Path>();
	
	void Awake ()
    {
        // Setting the static variable
        Instance = this;
	}
    // Sets the position based off of the number givin to the enemy
    public Vector3 GetSpawnPosition(int pathIndex)
    {
        return Paths[pathIndex].WayPoints[0].position;
    }
}

// showing the list of waypoints for inspector
[System.Serializable]
public class Path 
{
    public List<Transform> WayPoints = new List<Transform>();
}
