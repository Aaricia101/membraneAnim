using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : AbstractAnimationAction
{
    
    [SerializeField] private float speed;
    [SerializeField] private bool isBackwards;

    [SerializeField] private float startPosition;
    [SerializeField] private float endPosition;
    [SerializeField] private float currentPosition;

    //give the possibility to input vector3 or use an object's vector3
    [SerializeField] private Vector3 nextPosition = Vector3.zero;
    
    [SerializeField] private GameObject nextPositionUsingObject;

    [SerializeField] private Rigidbody rbOfObject;

    // Start is called before the first frame update

    public void Start()
    {
        rbOfObject = GetComponent<Rigidbody>();
    }

    public override void execute(float speedMultiplier, bool isBackward)
    {
        speed = 0.35f;
        speed *=  speedMultiplier;
        isBackwards = isBackward;
        
        currentPosition = transform.position.y;
        
       

        if (nextPosition == new Vector3(0,0,0))
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPositionUsingObject.transform.position, speed);
            //rbOfObject.MovePosition(Vector3.MoveTowards(transform.position, nextPositionUsingObject.transform.position, speed));

            if (transform.position == nextPositionUsingObject.transform.position)
            {
                setAnimationHasEnded(true);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed);
            //rbOfObject.MovePosition(Vector3.MoveTowards(transform.position, nextPosition, speed));

            if (transform.position == nextPosition)
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
