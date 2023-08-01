using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAnimationAction : MonoBehaviour

{
    [SerializeField] private int orderPosition;
    [SerializeField] private bool animationHasEnded;

    // Start is called before the first frame update
    public abstract void execute(float speedMultiplier, bool isBackward);

    public int getOrderPosition()
    {
        return orderPosition;
    }
    
    public bool getAnimationHasEnded()
    {
        return animationHasEnded;
    }
    
    public void setAnimationHasEnded(bool ended)
    {
        animationHasEnded = ended;
    }


}


