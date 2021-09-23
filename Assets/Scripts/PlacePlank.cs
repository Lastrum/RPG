using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlacePlank : MonoBehaviour
{
    public GameObject bridge;

    private void Awake()
    {
        bridge.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && PlayerController.hasPlank)
        {
            bridge.SetActive(true);
            PlayerController.hasPlank = false;
        }
    }
}
