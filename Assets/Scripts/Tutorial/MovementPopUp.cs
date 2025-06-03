using UnityEngine;
using System.Collections;

public class MovementPopUp : MonoBehaviour
{
    public GameObject PopUpPanel; 
    private float HideDelay = 1f;
    private bool HasMoved = false;

    IEnumerator HidePopUp()
    {
        yield return new WaitForSeconds(HideDelay); 
        PopUpPanel.SetActive(false);
    }
    void Start()
    {
        PopUpPanel.SetActive(true);
    }

    void Update()
    {
        if (!HasMoved && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            HasMoved = true;
            StartCoroutine(HidePopUp());
        }
    }
}
