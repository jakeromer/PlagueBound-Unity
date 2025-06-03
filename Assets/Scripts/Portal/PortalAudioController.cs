using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAudioController : MonoBehaviour
{
    public List<AudioClip> PortalAudioClips;
    public float PlayInterval = 3f;
    private AudioSource AudioSource;
    private bool PlayerInside = false;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInside = true;
            StartCoroutine(PlayRandomAudio());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInside = false;
            StopAllCoroutines();
        }
    }

    private IEnumerator PlayRandomAudio()
    {
        while (PlayerInside)
        {
            if (PortalAudioClips.Count > 0)
            {
                AudioClip RandomClip = PortalAudioClips[Random.Range(0, PortalAudioClips.Count)];
                AudioSource.clip = RandomClip;
                AudioSource.Play();
            }
            yield return new WaitForSeconds(PlayInterval);
        }
    }
}
