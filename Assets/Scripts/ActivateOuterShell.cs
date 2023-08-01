using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOuterShell : MonoBehaviour
{
    // Start is called before the first frame update
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
