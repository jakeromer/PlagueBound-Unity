using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StaticEffectController : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public Volume PostProcessVol;
    public float MaxGrainDistance = 5f;
    public float MaxGrainIntensity = 1f;
    private FilmGrain grain;


    void Start()
    {
        if (PostProcessVol.profile.TryGet<FilmGrain>(out grain))
        {
            grain.active = true;
        }
    }

    void Update()
    {
        float distance = Vector2.Distance(player.position, enemy.position);
        grain.intensity.value = Mathf.Clamp01(1 - (distance / MaxGrainDistance)) * MaxGrainIntensity;
    }
}