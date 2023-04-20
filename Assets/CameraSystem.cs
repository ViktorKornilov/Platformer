using UnityEngine;
using Vector2 = System.Numerics.Vector2;

[ExecuteAlways]
public class CameraSystem : MonoBehaviour
{
    public Transform target;
    [Range(0f,1f)]public float smoothness = 0.1f;
    
    private void LateUpdate()
    {
        if (!target) return;
        
        var targetPos = target.position;
        targetPos.z = -10;
        transform.position = Vector3.Lerp(transform.position, targetPos,1 - smoothness);
    }
}
