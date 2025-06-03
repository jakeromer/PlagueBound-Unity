using UnityEngine;

public class AudioController : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public AudioSource AudioSource;
    public AudioClip[] StringerClips;
    public float MinSoundDistance = 5f;
    public float MaxVolume = 1f;
    public float ClipDelay = 1f; 

    private int CurrentClipIndex = 0;
    private float NextClipTime;

    void Start()
    {

        AudioSource.volume = 0f;
        NextClipTime = Time.time;
    }

    void Update()
    {
        float distance = Vector2.Distance(player.position, enemy.position);
        float volume = Mathf.Clamp01(1 - (distance / MinSoundDistance)) * MaxVolume;
        AudioSource.volume = volume;

        if (Time.time >= NextClipTime && !AudioSource.isPlaying)
        {
            PlayNextClip();
            NextClipTime = Time.time + ClipDelay;
        }
    }

    void PlayNextClip()
    {
        if (StringerClips.Length == 0) return;

        AudioSource.clip = StringerClips[CurrentClipIndex];
        AudioSource.Play();

        CurrentClipIndex = (CurrentClipIndex + 1) % StringerClips.Length;
    }
}
