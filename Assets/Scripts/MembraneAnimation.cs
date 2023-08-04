using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MembraneAnimation : MonoBehaviour
{

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
            //rbOfObject.MovePosition(Vector3.MoveTowards(transform.position, originalPosition, 0.5f));
        }

        // if (Math.Round(transform.position.y) == Math.Round(originalPosition.y))
        // {
        //     followParticule = true;
        // }

        // if (timePassed >= 1f)
        // {
        //     followParticule = false;
        //     transform.position = Vector3.MoveTowards(transform.position, originalPosition, 0.5f); 
        // }

        
        
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("FullParticule") && followParticule)
        {
            
            hasCollided = true;
            
            Vector3 test = new Vector3(transform.position.x- 0.6f, transform.position.y , transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, test, 0.5f);
            transform.LookAt(objectToLookAt.transform,  Vector3.left);

        }

    }

   
}
