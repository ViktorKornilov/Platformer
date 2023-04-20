using System;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Camera camera;
    [Range(0f,1f)]public float ratio = 0.5f;

    private void Start()
    {
        camera = Camera.main;
    }

    private void LateUpdate()
    {
        var targetPos = camera.transform.position;
        targetPos.z = 0;
        
        transform.position = targetPos * ratio;
    }
}
