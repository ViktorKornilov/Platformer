using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public AudioClip collectSound;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            Audio.Play(collectSound);
        }
    }
}
