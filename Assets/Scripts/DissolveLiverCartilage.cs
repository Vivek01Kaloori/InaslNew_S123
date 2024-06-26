using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveLiverCartilage : MonoBehaviour
{
    public Material targetMaterial; // Replace with the name of your material
    public float speed = 0.001f; // Adjust speed for faster/slower changes (default: 0.1)
    private float currentValue = 0f;
    private float timer = 0f; // Added timer variable

    void Update()
    {
        timer += Time.deltaTime; // Update timer each frame

        if (timer >= 6f) // Check if 1 second has passed
        {
            currentValue += speed;
        }

        targetMaterial.SetFloat("_dissolveStrength", currentValue); // Replace "_FloatName" with the actual float name in your shader graph
    }
}
