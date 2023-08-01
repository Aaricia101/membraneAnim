using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : AbstractAnimationAction
{

    [SerializeField] private float speed;
    [SerializeField] private bool isBackwards;
    [SerializeField] private float pivotYPosition;

    [SerializeField] private GameObject pivotObject;
    
    
    public override void execute(float speedMultiplier, bool isBackward)
    {
        speed = 10;
        speed *=  speedMultiplier;
        isBackwards = isBackward;

        pivotYPosition = pivotObject.transform.position.y;
        
        
        if (isBackwards)
        {
            transform.RotateAround(new Vector3(pivotObject.transform.position.x, pivotYPosition, pivotObject.transform.position.z), new Vector3(0, 0.5f, 0), -speed*Time.deltaTime);
 
        }
        else
        {
            transform.RotateAround(new Vector3(pivotObject.transform.position.x, pivotYPosition, pivotObject.transform.position.z), new Vector3(0, 1, 0), speed*Time.deltaTime);

        }

        
        
    }

}
