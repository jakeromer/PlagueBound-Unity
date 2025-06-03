using UnityEngine;
using System.Collections;
using Pathfinding;

public class BatteryPopUp : MonoBehaviour
{
    public GameObject BatteryPU;
    public GameObject CrowInstance;
    public GameObject CrowAI;
    private float PopDelay = 3f;
  
    void Start()
    {
        BatteryPU.SetActive(false);
        CrowInstance.GetComponent<EnemyChase>().enabled = false;
        CrowAI.GetComponent<AIPath>().canMove = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            ShowPopUp();
            CrowInstance.GetComponent<EnemyChase>().enabled = true;
            CrowAI.GetComponent<AIPath>().canMove = true;
            
            Destroy(GetComponent<Collider2D>());
            StartCoroutine(ClosePopUp());
        }
    }
    
    void ShowPopUp()
    {
        BatteryPU.SetActive(true);
    }

    IEnumerator ClosePopUp()
    {
        yield return new WaitForSeconds(PopDelay);  
        BatteryPU.SetActive(false);
    }
}
