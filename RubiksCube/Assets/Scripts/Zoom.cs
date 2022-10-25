using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float speed = 5;

    void Awake()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        cam.fieldOfView -= Input.mouseScrollDelta.y * speed;
    }
}
