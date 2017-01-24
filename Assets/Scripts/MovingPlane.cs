using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlane : MonoBehaviour {

    public Transform[] points;
    public int timePerCycle = 5;
    private int currentPoint = 0;
    private int nextPoint = 1;
    private float currentStep = 0;

    void FixedUpdate()
    {
        currentStep += Time.fixedDeltaTime / timePerCycle;
        if (currentStep <= 1)
        {
            transform.position = new Vector3(Mathf.Lerp(points[currentPoint].position.x, points[nextPoint].position.x, currentStep), Mathf.Lerp(points[currentPoint].position.y, points[nextPoint].position.y, currentStep), Mathf.Lerp(points[currentPoint].position.z, points[nextPoint].position.z, currentStep));
        }
        else
        {
            currentStep = 0;
            currentPoint = nextPoint;
            if (nextPoint == points.Length - 1)
            {
                nextPoint = 0;
            } else
            {
                nextPoint++;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
