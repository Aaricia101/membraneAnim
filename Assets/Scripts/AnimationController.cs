using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;

    [SerializeField] private bool isPaused;

    [SerializeField] private bool isStopped;

    [SerializeField] private bool isBackward;

    [SerializeField] private List<AbstractAnimationAction> actions;

    [SerializeField] private int actionIndexInExecution;

    private void Start()
    {
        actionIndexInExecution = 0;
        

        foreach (var a in GetComponentsInChildren<AbstractAnimationAction>())
        {
            actions.Add(a);
        }
    }

    void Update()
    {

        if (isStopped)
        {
            Destroy(gameObject);
        }
        else
        {
            if (!isPaused)
            {
                
                ExecuteCurrentActions();

            }

        }
    }

    void IncreaseSpeed(float speedIncrease)
    {
        speedMultiplier += speedIncrease;
    }
    
    void DecreaseSpeed(float speedDecrease)
    {
        speedMultiplier -= speedDecrease;
    }

    void Pause()
    {
        isPaused = true;
    }
    
    void Resume()
    {
        isPaused = false;
    }

    void Stop()
    {
        Destroy(gameObject);

    }

    void SetBackwards(bool isBackwards)
    {
        isBackward = isBackwards;
    }

    float GetSpeed()
    {
        return speedMultiplier;
    }

    void ExecuteAllActions()
    {
        foreach (var a in actions)
        {
            a.execute(GetSpeed(), isBackward);
        }
    }
    
    void ExecuteCurrentActions()
    {
        foreach (var a in actions)
        {
            

            if (a.getOrderPosition() == actionIndexInExecution && a.getAnimationHasEnded() == false)
            {
                
                a.execute(GetSpeed(), isBackward);
                

            }
            
            if (a.getOrderPosition() == actionIndexInExecution &&a.getAnimationHasEnded())
            {
                actionIndexInExecution++;
                
            }
        }
    }
}
