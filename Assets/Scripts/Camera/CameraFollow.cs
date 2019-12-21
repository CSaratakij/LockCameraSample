using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float damp = 0.025f;

    [SerializeField]
    Transform target;

    Vector3 offset;
    Vector3 destination;

    void Awake()
    {
        Initialize();
    }

    void LateUpdate()
    {
        FollowHandler();
    }

    void Initialize()
    {
        offset = transform.position - target.position;
    }

    void FollowHandler()
    {
        destination = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, destination, damp);
    }
}

