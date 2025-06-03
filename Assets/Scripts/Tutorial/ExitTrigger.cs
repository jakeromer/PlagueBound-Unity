using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) { LoadMainLevel(); }
    }

    void LoadMainLevel()
    {
        SceneManager.LoadScene("Main Level");
    }
}
