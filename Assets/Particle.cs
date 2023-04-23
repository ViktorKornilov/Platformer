using UnityEngine;

public class Particle : MonoBehaviour
{
    private void Start()
    {
        Destroy( gameObject,Random.Range(2f,3f));
    }
}
