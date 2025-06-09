using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    Vector3 offset = new Vector3(0f, 1.7f, 0f); 



    private void FixedUpdate()
    {
        transform.position = playerTransform.position + offset;
    }
}
