using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateDNA : AbstractAnimationAction
{
    [SerializeField] private GameObject dnaObject;
    
    [SerializeField] private float speed;
    
    //variable used for going backward
    [SerializeField] private bool isBackwards;

    [SerializeField] private float startPosition;
    [SerializeField] private float endPosition;
    [SerializeField] private float currentPosition;

    //give the possibility to input vector3 or use an object's vector3
    [SerializeField] private Vector3 nextPosition = Vector3.zero;
    
    [SerializeField] private GameObject nextPositionUsingObject;
    

    // Start is called before the first frame update

    public void Start()
    {
        
    }

    public override void execute(float speedMultiplier, bool isBackward)
    {
        dnaObject.SetActive(true);
        speed = 0.2f;
        speed *=  speedMultiplier;
        isBackwards = isBackward;
        
        currentPosition = dnaObject.transform.position.y;
        
       

        //using object
        if (nextPosition == new Vector3(0,0,0))
        {
            dnaObject.transform.position = Vector3.MoveTowards(dnaObject.transform.position, nextPositionUsingObject.transform.position, speed);

            if (dnaObject.transform.position == nextPositionUsingObject.transform.position)
            {
                setAnimationHasEnded(true);
            }
        }
        //using a position
        else
        {
            dnaObject.transform.position = Vector3.MoveTowards(dnaObject.transform.position, nextPosition, speed);

            if (dnaObject.transform.position == nextPosition)
            {
                setAnimationHasEnded(true);
            }
        }

        




        /*
        if (isBackwards)
        {
            if (Math.Round(currentPosition) == Math.Round(startPosition))
            {
                
                transform.position = new Vector3(transform.position.x, endPosition+speed, transform.position.z);

            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y+speed, transform.position.z);

            }
        }
        else
        {
            if (Math.Round(currentPosition) == Math.Round(endPosition))
                
            {
                
                transform.position = new Vector3(transform.position.x, startPosition-speed, transform.position.z);

            }
            else
            {

                
                transform.position = new Vector3(transform.position.x, transform.position.y-speed, transform.position.z);

            }
        }*/


    }
}
