using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 30f; // Adjust the speed as needed

    void Update()
    {
        // Rotate the GameObject around its y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
