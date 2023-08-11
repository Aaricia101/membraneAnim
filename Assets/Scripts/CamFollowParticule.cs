using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowParticule : MonoBehaviour
{
    
    //for code based on a list of objects
    [SerializeField] private Transform camera;
    [SerializeField] private List<GameObject> listOfGuides;

    [SerializeField] private int indexForList;
    
    
    //for code based on time
    [SerializeField] private Transform target;

    [SerializeField] private GameObject dnaObject;
    
    [SerializeField] private GameObject cellObject;

    

    [SerializeField] private float spaceBetweenCamAndTarget;
    
    [SerializeField] private float timePassed;


    [SerializeField] private float speedOfCam;
    private void Start()
    {
        spaceBetweenCamAndTarget = -12;
        timePassed = 0;
        indexForList = 0;

        camera.position = listOfGuides[indexForList].transform.position;

    }

    void Update()
    {
        
        //logic based of a list of guides (script added on the particule)
        timePassed += Time.deltaTime;

        if (transform.position.x <= listOfGuides[indexForList].transform.position.x-3f)
        {
            indexForList++;
            camera.transform.position = listOfGuides[indexForList].transform.position;

            
        }
        
        //logic based on time (script has to be added on the camera)
        
        // if (dnaObject.activeSelf)
        // {
        //     target =  cellObject.transform;
        //     spaceBetweenCamAndTarget = -3;
        //     camera.transform.position = target.transform.position + new Vector3(0, 2, spaceBetweenCamAndTarget);
        //     transform.LookAt(cellObject.transform);
        //     enabled = false;
        //
        // }
        /*
        else if (timePassed > speedOfCam && indexForList<listOfGuides.Count)
        {
    
            
            camera.transform.position = listOfGuides[indexForList].transform.position;
            indexForList++;
  
            timePassed = 0;
        
        }*/

       

    }
}
    
    
