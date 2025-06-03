using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class JumpscareController : MonoBehaviour
{
    public Animator JumpscareAnimator;
    public Collider2D JumpscareCollider;
    public AudioSource JumpscareClip;
    public EnemyChase CrowCheck;
    public GameObject DeathPanel;
    public GameObject Flashlight;
    public Movement PlayerMovement;
    public Battery PlayerBattery;
    private bool TriggeredJumpscare = false;

    void Start()
    {
        DeathPanel.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == CrowCheck.gameObject && !TriggeredJumpscare)
        {
            if (CrowCheck.GetInLight() == false)
            {         
                StartCoroutine(StartJumpscare());
                StartCoroutine(HandleGameDeath());
                TriggeredJumpscare = true;
            }
        }
    }
    private IEnumerator StartJumpscare()
    {
        PlayerMovement.enabled = false;
        JumpscareClip.Play();
        JumpscareAnimator.SetTrigger("StartScare");
        yield break;

    }

    private IEnumerator HandleGameDeath()
    {
        yield return new WaitForSeconds(1f);
        Flashlight.SetActive(false);
        PlayerBattery.KillBattery();
        yield return new WaitForSeconds(3f);
        ShowDeathPanel();
    }

    private void ShowDeathPanel()
    {
        DeathPanel.SetActive(true);
    }

}

