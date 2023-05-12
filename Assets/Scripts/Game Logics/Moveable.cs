using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        // Move the pipe to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Check if pipe is offscreen
        if (transform.position.x < -20f)
        {
            // Destroy the pipe
            Destroy(gameObject);
        }
    }
}