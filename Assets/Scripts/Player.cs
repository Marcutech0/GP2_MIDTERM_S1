using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Player : MonoBehaviour
{
    public Transform[] targets; // The array of targets
    public float range = 11;
    private float detectionRadius = 11;

    private Transform currentTarget; // The current target
    private bool searchingForNewTarget = false; // Flag to control target search

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, Vector3.up, detectionRadius);
    }
#endif

    void Update()
    {
        // Check if the current target exists and is not destroyed within the circle
        if (currentTarget == null || !currentTarget.gameObject.activeSelf || Vector3.Distance(currentTarget.position, transform.position) > detectionRadius)
        {
            // If not, initiate a search for a new closest target within the circle
            if (!searchingForNewTarget)
            {
                StartCoroutine(SearchForNewTarget());
            }
        }

        // If a valid current target exists, rotate the player to face it
        if (currentTarget != null)
        {
            Vector3 relativePos = currentTarget.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime); // Smoothly rotate to face the target
        }
    }

    private IEnumerator SearchForNewTarget()
    {
        searchingForNewTarget = true;

        while (currentTarget == null || !currentTarget.gameObject.activeSelf || Vector3.Distance(currentTarget.position, transform.position) > detectionRadius)
        {
            currentTarget = FindClosestTargetWithinCircle();
            yield return new WaitForSeconds(1.0f); // Adjust the time interval as needed
        }

        searchingForNewTarget = false;
    }

    private Transform FindClosestTargetWithinCircle()
    {
        Transform closestTarget = null;
        float closestDistance = float.MaxValue;

        foreach (Transform target in targets)
        {
            float dist = Vector3.Distance(target.position, transform.position);
            if (dist <= detectionRadius && dist <= range && dist < closestDistance)
            {
                closestDistance = dist;
                closestTarget = target;
            }
        }

        return closestTarget;
    }

    public void OnCurrentTargetDestroyed()
    {
        // Called when the current target is destroyed, switch to the next closest target
        currentTarget = FindClosestTargetWithinCircle();
    }
}
