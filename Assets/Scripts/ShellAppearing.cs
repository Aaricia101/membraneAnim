using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellAppearing : MonoBehaviour
{

    private MeshRenderer shellMesh;
    private bool deactivateOnce;
    [SerializeField] private List<GameObject> objectToBeDesactivated;
    

    // Start is called before the first frame update
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


    private void OnTriggerEnter(Collider other)
    {

        /*if (other.gameObject.name == "OuterShellTrigger")
        {
            if (gameObject.name == "Phospholipid.741")
            {

                foreach (var a in objectToBeDesactivated)
                {
                    a.SetActive(false);
                }
            
            }
            shellMesh.enabled = true;
        }*/

        
        
    }
    
}
