using UnityEngine;
using UnityEngine.SceneManagement;

[SelectionBase]
public class Portal : MonoBehaviour
{
    public string nextLevel;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
