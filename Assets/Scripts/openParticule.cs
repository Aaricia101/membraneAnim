using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class openParticule : AbstractAnimationAction
{

    [SerializeField] private List<GameObject> itemsToBeRemoved;

    [SerializeField] private int NbrItems;

    [SerializeField] private int index;

    private float time;

    [SerializeField] private float timeDelay;
    // Start is called before the first frame update

    public void Start()
    {
        time = 0;
        NbrItems = itemsToBeRemoved.Count;
        index = 0;
    }

    public override void execute(float speedMultiplier, bool isBackward)
    {

        time = time + 1f * Time.deltaTime;
        if (time >= timeDelay)
        {
            time = 0f;
            
            if (index < NbrItems)
            {
                itemsToBeRemoved[index].SetActive(false);
                index++;
            }

            if (index == NbrItems)
            {
                setAnimationHasEnded(true);
            }
        }
        
       
        



    }

    // Update is called once per frame
}
