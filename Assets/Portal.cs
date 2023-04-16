using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[SelectionBase]
public class Portal : MonoBehaviour
{
    public string nextLevel;
    public bool isPlayerInPortal;
    public float playerStandTime;
    public float teleportTime = 1;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerStandTime += Time.deltaTime;
            
            // fade player based on time
            col.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - playerStandTime);
            
            if(playerStandTime > teleportTime)Teleport();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerStandTime = 0;
            col.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }


    void Teleport()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
