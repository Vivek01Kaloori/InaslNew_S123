using UnityEngine;

public class RotateOnce : MonoBehaviour
{
    public float initialSlowSpeed = 30f; // Initial slow rotation speed (degrees per second)
    public float fastSpeed = 300f;  // Fast rotation speed (degrees per second)
    public float slowSpeed = 60f;   // Slow rotation speed (degrees per second)
    private float totalRotation = 0f; // Track total rotation
    private bool rotationComplete = false; // Track if rotation is complete

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

        // Apply rotation
        transform.Rotate(0f, rotationStep, 0f);
        totalRotation += rotationStep;

        // Check if rotation is complete
        if (totalRotation >= 360f)
        {
            rotationComplete = true;
            Debug.Log("Rotation complete");
        }
    }
}
