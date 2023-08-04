using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowParticule : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private GameObject dnaObject;

    [SerializeField] private float spaceBetweenCamAndTarget;

    private void Start()
    {
        spaceBetweenCamAndTarget = -10;
    }

    void Update()
    {

        if (dnaObject.activeSelf)
        {
            target =  dnaObject.transform;
            spaceBetweenCamAndTarget = -3;

        }
        transform.position = target.transform.position + new Vector3(0, 1, spaceBetweenCamAndTarget);

    }
}
    
    
