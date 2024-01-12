using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 1f)]
    private float rotationSpeed = 0.05f;

    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed, Space.World);
    }
}
