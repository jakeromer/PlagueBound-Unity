using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCheck : MonoBehaviour
{
    private PlayerInventory CheckInventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript CheckScript = other.GetComponent<PlayerScript>();
            if (CheckScript != null && CheckScript.PlayerInventory != null)
            {
                CheckInventory = (PlayerInventory)CheckScript.PlayerInventory;

                if (CheckInventory.ItemCount() == 4)
                {
                    EndGame();
                }
            }
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene("End"); 
    }
    
}
