using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOuterShell : MonoBehaviour
{
    // this script is put on object 'OuterShelltrigger'. Initially the outer white shell is disabled and once the particule touches this the outershell is activated.
    // Ps.: Even though the white outer shell is activated it is NOT enabled so it's invisible for now
    [SerializeField] private GameObject GameObjectToActivate;
    void Start()
    {
        GameObjectToActivate.SetActive(false);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FullParticule"))
        {
            GameObjectToActivate.SetActive(true);
        }
    }
}
