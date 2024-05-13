using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTransform : MonoBehaviour
{
    [Header("Rotation")]
    public float xSpeed = 0f;
    public float ySpeed = 70f;
    public float zSpeed = 0f;

    [Header("Hovering")]
    public float frequency = 1f;
    public float amplitude = 0.2f;
    Vector3 originalPosition;
    Vector3 temporaryPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(
            xSpeed * Time.deltaTime,
            ySpeed * Time.deltaTime,
            zSpeed * Time.deltaTime
        );

        temporaryPosition = originalPosition;
        temporaryPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = temporaryPosition;
    }
}
