using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Enemymove : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    //[SerializeField] float waitTime = 1.0f;
    [SerializeField] [Range(0f,5f)]float speed = 1.0f;

    Enemy enemy;
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
        //InvokeRepeating("PrinWaypointName", 0, 1f);
        
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();
        //GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path"); 
        GameObject parent= GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            WayPoint waypoint = child.GetComponent<WayPoint>();

            if( waypoint != null)
            {
                path.Add(waypoint);
            }
        }

        /*foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<WayPoint>());

        }*/
    }
    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    IEnumerator FollowPath()
    {
        foreach (WayPoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);
            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
            //Debug.Log(waypoint.name);
            //transform.position = waypoint.transform.position;
            //yield return new WaitForSeconds(waitTime);
        }
       FinishPath();
    }
}
