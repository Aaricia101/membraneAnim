using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemMultiplier : AbstractAnimationAction
{
    [SerializeField] private float speed;
    [SerializeField] private bool isBackwards;

    [SerializeField] private GameObject spawnObjectPrefab;

    [SerializeField] private float rangeX;

    [SerializeField] private float rangeZ;

    [SerializeField] private float rangeY;

    [SerializeField] private float halfWidth;
    [SerializeField] private int countList;

    [SerializeField] private List<GameObject> listObject;

    [SerializeField] private Vector3 spawnCenter;

    [SerializeField] private GameObject parentOfObjects;

    [SerializeField] private GameObject spawnObject;

    [SerializeField] private bool stayInside;

    private GameObject randomObject;
    private Vector3 spawnPosition;
    private float angle;

    [SerializeField] private int indexLoop;


    [SerializeField] private float configurateSpeedBetweenSpawns;
    
    //[SerializeField] private int 


    private float timeToGo;

    public void Start()
    {
        timeToGo = Time.fixedTime;
        spawnObject = Instantiate(spawnObjectPrefab);
        listObject.Add(spawnObject);

        halfWidth = listObject[0].GetComponent<MeshRenderer>().bounds.size.x;
        listObject[0].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        listObject[0].transform.position = spawnObjectPrefab.transform.position;
        spawnObject.transform.SetParent(parentOfObjects.transform);

        indexLoop = 0;
    }

    public override void execute(float speedMultiplier, bool isBackward)
    {
        if (Time.fixedTime >= timeToGo)
        {
            if (isBackward)
            {
                removeLastObject();
            }
            else
            {
                if (indexLoop < 10)
                {
                    stayInside = false;
                    spawnObject = Instantiate(spawnObjectPrefab);
                    listObject.Add(spawnObject);

                    randomObject = getRandomSpawnObject();

                    //spawn from the last object
                    findAndAssignObjectPosition(spawnObject, randomObject);

                    findAndAssignObjectRotation(spawnObject, randomObject);

                    stayInside = Physics.Raycast(spawnObject.transform.position, -Vector3.up, 30);


                    while (!stayInside)
                    {
                        //spawn from the last object
                        findAndAssignObjectPosition(spawnObject, randomObject);

                        findAndAssignObjectRotation(spawnObject, randomObject);
                        
                        stayInside = Physics.Raycast(spawnObject.transform.position, -Vector3.up, 30);
                        indexLoop++;
                    }


                    spawnObject.transform.SetParent(parentOfObjects.transform);
                }


                timeToGo = Time.fixedTime + speedMultiplier * configurateSpeedBetweenSpawns;
            }
        }
    }

    void removeLastObject()
    {
        if (listObject.Count - 1 != 0)
        {
            Destroy(listObject[listObject.Count - 1]);
            listObject.RemoveAt(listObject.Count - 1);
        }

        indexLoop = 0;
    }

    void findAndAssignObjectPosition(GameObject spawnObject, GameObject randomObject)
    {
        rangeX = randomObject.transform.position.x + halfWidth;
        rangeZ = randomObject.transform.position.z;


        spawnPosition = new Vector3(rangeX, rangeY, rangeZ);

        spawnObject.transform.position = spawnPosition;
    }
    
    void findAndAssignObjectRotation(GameObject spawnObject, GameObject randomObject)
    {
        angle = Random.Range(1, 360);

        spawnObject.transform.RotateAround(randomObject.transform.position, Vector3.up, angle);
    }

    private GameObject getRandomSpawnObject()
    {
        countList = Random.Range(1, listObject.Count);


        return listObject[countList - 1];

        
    }

}