using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine.SceneManagement;

public class EnemyChase : MonoBehaviour
{   
    public Animator CrowAnimator;
    public Battery PlayerBattery;
    public AIPath AiPath;
    private SpriteRenderer SpriteCrow;
    private bool IsInLight = false;
    private Rigidbody2D CrowRb;
    
    void Awake()
    {
        CrowAnimator.SetBool("isWalking", false);
        SpriteCrow = GetComponent<SpriteRenderer>();
        CrowRb = GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().name == "Tutorial") { AiPath.canMove = false; }
        else { AiPath.canMove = true; }
    }
    
    void Update()
    {
        if (IsInLight) 
        {
            CrowRb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
            AiPath.canMove = false;
            return; 
        }
        AiPath.canMove = true;
        if (AiPath.desiredVelocity.sqrMagnitude > 0)
        {
            CrowAnimator.SetBool("isWalking", true);
            if (AiPath.desiredVelocity.x < 0)
            {
                SpriteCrow.flipX = true;
            }
            else if (AiPath.desiredVelocity.x > 0)
            {
                SpriteCrow.flipX = false;
            }
        }
        else
        {
            CrowAnimator.SetBool("isWalking", false);
        }
        SetSpeed();
    }

    public void StopChasing()
    {
        IsInLight = true;
        CrowAnimator.SetBool("isWalking", false);
    }

    public void ResumeChasing()
    {
        IsInLight = false;
    }

    public bool GetInLight()
    {
        return IsInLight;
    }

    private void SetSpeed()
    {
        if (PlayerBattery != null)
        {
            if (PlayerBattery.GetBattery() > 40f)
            {
                AiPath.maxSpeed = 1.45f;
            }
            else { AiPath.maxSpeed = 1.1f;}
        }
    }
}
