﻿/*
 * Copyright (c) 2018 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float moveSpeed = 3f;
    public int goldDrop = 10;

    public int pathIndex = 0;

    private int wayPointIndex = 0;

    void OnGotToLastWayPoint()
    {
        Die();
    }

    public void TakeDamage(float amountOfDamage)
    {
        health -= amountOfDamage;

        if (health <= 0)
        {
            Die();
        }
    }

    //void Update()
    //{
    //    // while waypoints are left update the movement
    //    if (wayPointIndex < WayPointManager.Instance.Paths[pathIndex].WayPoints.Count)
    //    {
    //        UpdateMovement();
    //    }
    //    else
    //    {
    //        // there are none left so call function
    //        OnGotToLastWayPoint();
    //    }
    //}


    void Update()
    {
        //1
        if (wayPointIndex < WayPointManager.Instance.Paths[pathIndex].WayPoints.Count)
        {
            UpdateMovement();
        }
        else
        { // 2
            OnGotToLastWayPoint();
        }
    }

    private void UpdateMovement()
    {
        // next waypoint is next position to go to
        Vector3 targetPosition = WayPointManager.Instance.Paths[pathIndex].WayPoints[wayPointIndex].position;

        // move towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // look at the next waypoint
        // transform.LookAt(targetPosition);
        transform.localRotation = UtilityMethods.SmoothlyLook(transform, targetPosition);


        // if the enemy is close to the waypoint set up the next one
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            wayPointIndex++;
        }
    }

    void Die()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
