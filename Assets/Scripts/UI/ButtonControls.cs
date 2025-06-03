using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControls: MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Main Menu"); 
    }
}