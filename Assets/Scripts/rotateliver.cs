using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateliver : MonoBehaviour
{
    public float initialSlowSpeed = 30f; // Initial slow rotation speed (degrees per second)
    public float fastSpeed = 300f;  // Fast rotation speed (degrees per second)
    public float slowSpeed = 60f;   // Slow rotation speed (degrees per second)
    public float rotationInterval = 2f; // Time interval for each rotation cycle (seconds)

    private float totalRotation = 0f; // Track total rotation
    private float timer = 0f; // Track time elapsed
    private bool isRotating = false; // Track if rotation is currently happening

    void Update()
    {
        timer += Time.deltaTime;

        // Start rotation when timer exceeds interval
        if (timer >= rotationInterval && !isRotating)
        {
            timer = 0f;
            totalRotation = 0f;
            isRotating = true;
        }

        if (isRotating)
        {
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

            // Apply rotation
            transform.Rotate(0f,0f,rotationStep);
            totalRotation += rotationStep;

            // Check if rotation is complete
            if (totalRotation >= 360f)
            {
                isRotating = false;
                Debug.Log("Rotation complete");
            }
        }
    }
}