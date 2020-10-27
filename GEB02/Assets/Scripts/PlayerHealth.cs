﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    private Vector3 startPos;
    private bool isInvincible = false;
    [SerializeField] private float invicibilityTimer;
    private void Start()
    {
        startPos = transform.position;
    }

    /// <summary>
    /// Takes damage from an enemy. Starts invincibility and checks for death
    /// </summary>
    /// <param name="value"></param>
    public void TakeDamage(int value)
    {
        if (!isInvincible)
        {
            health -= value;
            isInvincible = true;
            Invoke("StopInvincibility", invicibilityTimer);
        }
        if (health <= 0)
        {
            Death();
        }
    }

    private void StopInvincibility()
    {
        isInvincible = false;
    }

    private void Death()
    {
        transform.position = startPos;
    }
}
