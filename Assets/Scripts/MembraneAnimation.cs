using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MembraneAnimation : MonoBehaviour
{
    
    //this script moves some objects on the membrane to make it seems like the membrane is wrapping around the particule

    [SerializeField] private Vector3 originalPosition;
    [SerializeField] private Vector3 currentPosition;
    [SerializeField] private float timePassed;

    [SerializeField] private bool followParticule;

    [SerializeField] private bool hasCollided;
    [SerializeField] private Rigidbody rbOfObject;

    [SerializeField] private GameObject objectToLookAt;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        followParticule = true;
        timePassed = 0;
        hasCollided = false;
        rbOfObject = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        
        //here when it reaches a certain time, the moved membrane object will automatically go back to its initial position
        
        if (hasCollided)
        {
            timePassed += Time.deltaTime; 
        }

        if (timePassed >= 0.4f)
        {
            followParticule = false;
            
        
        }
        
        if (!followParticule)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, 0.5f); 

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //when the particule triggers the membrane some particule of the membrane wall will move slightly forwards.
        
        if (other.gameObject.CompareTag("FullParticule") && followParticule)
        {
            
            hasCollided = true;
            
            Vector3 test = new Vector3(transform.position.x- 0.6f, transform.position.y , transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, test, 0.5f);
            transform.LookAt(objectToLookAt.transform,  Vector3.left);

        }

    }

   
}
