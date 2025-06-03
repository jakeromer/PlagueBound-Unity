using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class FirstEncounter : MonoBehaviour
{
    public GameObject EncounterPop;
    public GameObject RunPopUp;
    public GameObject PlayerFlashlight;
    public Tilemap TempWall;
    public AudioSource WallBreaking;
    private bool CrowOn = false;

    void Start()
    {
        EncounterPop.SetActive(false);
        RunPopUp.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy") && !CrowOn)
        {
            CrowOn = true;
            StartCoroutine(FreezeSequence());
        }
    }

    IEnumerator FreezeSequence()
    {   
        PlayerFlashlight.SetActive(false);
        Time.timeScale = 0;
        EncounterPop.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        EncounterPop.SetActive(false);

        Time.timeScale = 1;
        PlayerFlashlight.SetActive(true);
        WallBreaking.Play();
        TempWall.ClearAllTiles();
        RunPopUp.SetActive(true);
        yield return new WaitForSecondsRealtime(2f); 
        RunPopUp.SetActive(false);
    }
}
