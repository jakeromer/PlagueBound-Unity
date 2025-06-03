using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject ControlsMenu; 
    private bool IsShowingControls = false;

    void Start()
    {
        ControlsMenu.SetActive(false);
    }

    void Update()
    {
        if (IsShowingControls && Input.GetKeyDown(KeyCode.E))
        {
            ToggleControls(); 
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ToggleControls()
    {
        IsShowingControls = !IsShowingControls;  
        ControlsMenu.SetActive(IsShowingControls); 
    }

}
