using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellAppearing : MonoBehaviour
{

    private MeshRenderer shellMesh;
    private bool deactivateOnce;
    [SerializeField] private List<GameObject> objectToBeDesactivated;
    

    // this script is added to every single objects of the white outer shell. The purpose is to enable (make them visible) each object of the white outer shell. 
    //In addition "Phospholipid.305" is one of the last object to pass through so, after it passes through, the orange inside particule will disable itself to enhance performance.
    void Start()
    {
        shellMesh = gameObject.GetComponent<MeshRenderer>();
        shellMesh.enabled = false;
        deactivateOnce = false;
    }

    private void Update()
    {

        if (gameObject.transform.position.x < 0)
        {
            shellMesh.enabled = true;
            
            if (gameObject.name == "Phospholipid.305")
            {
                if (deactivateOnce == false)
                {
                    foreach (var a in objectToBeDesactivated)
                    {
                        a.SetActive(false);
                    }

                    deactivateOnce = true;
                }

                
            
            }

        }
    }

    
    
}
