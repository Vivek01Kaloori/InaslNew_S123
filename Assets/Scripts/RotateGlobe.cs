using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGlobe : MonoBehaviour
{
    public float initialSlowSpeed = 30f; // Initial slow rotation speed (degrees per second)
    public float fastSpeed = 300f;  // Fast rotation speed (degrees per second)
    public float slowSpeed = 60f;   // Slow rotation speed (degrees per second)
    private float totalRotation = 0f; // Track total rotation
    private bool rotationComplete = false; // Track if rotation is complete

    // Rotation axis which is 300 degrees to the Y-axis
    private Vector3 customAxis;

    void Start()
    {
        // Calculate the custom axis 300 degrees relative to the Y-axis
        customAxis = Quaternion.Euler(0, 300, 0) * Vector3.up;
    }

    void Update()
    {
        if (rotationComplete) return; // Stop rotation if already complete

        float rotationStep;
        if (totalRotation < 10f)
        {
            // Initial slow rotation for the first 10 degrees
            rotationStep = initialSlowSpeed * Time.deltaTime;
        }
        else if (totalRotation < 300f)
        {
            // Fast rotation
            rotationStep = fastSpeed * Time.deltaTime;
        }
        else
        {
            // Slow rotation
            rotationStep = slowSpeed * Time.deltaTime;
        }

        // Cap the rotation step to avoid overshooting
        rotationStep = Mathf.Min(rotationStep, 360f - totalRotation);

        // Apply rotation around the custom axis
        transform.RotateAround(transform.position, customAxis, rotationStep);
        totalRotation += rotationStep;

        // Check if rotation is complete
        if (totalRotation >= 360f)
        {
            rotationComplete = true;
            Debug.Log("Rotation complete");
        }
    }
}

