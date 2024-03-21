﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aidkit : MonoBehaviour
{
    public float healAmount = 50;

    private void OnTriggerEnter(Collider other)
    {
        var PlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (PlayerHealth != null)
        {
            PlayerHealth.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }

    
}