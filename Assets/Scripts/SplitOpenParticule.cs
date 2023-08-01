using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitOpenParticule : AbstractAnimationAction
{

    [SerializeField] private GameObject topOuterLayer;
    
    [SerializeField] private GameObject bottomParticuleLayer;
    
    [SerializeField] private GameObject bottomInsideParticuleLayer;
    
    [SerializeField] private GameObject topParticuleLayer;
    
    [SerializeField] private GameObject topInsideParticuleLayer;

    [SerializeField] private Vector3 topOuterLayerPosition = new Vector3();

    [SerializeField] private float YPosition;
    
    [SerializeField] private float speed;

    [SerializeField] private bool activateAll;

    
    // Start is called before the first frame update
    void Start()
    {
        
        YPosition = topOuterLayer.transform.position.y;
        activateAll = false;



    }

    // Update is called once per frame

    public override void execute(float speedMultiplier, bool isBackward)
    {

        if (activateAll == false)
        {
            topParticuleLayer.SetActive(true);
            topInsideParticuleLayer.SetActive(true);
            bottomParticuleLayer.SetActive(true);
            bottomInsideParticuleLayer.SetActive(true);
            activateAll = true;
        }
 
        speed = 0.35f;
        speed *=  speedMultiplier;
        topOuterLayerPosition = topOuterLayer.transform.position;

        topOuterLayer.transform.position = Vector3.MoveTowards(topOuterLayerPosition, new Vector3(topOuterLayerPosition.x, YPosition+45f, topOuterLayerPosition.z), speed);

        //move up the white outer layer
        if (topOuterLayer.transform.position.y > 15)
        {
            topOuterLayer.SetActive(false);

            //once the outer layer reaches the peak it deactivates and the particule layer starts to move
            if (topParticuleLayer.transform.position.y < 15)
            {
                topParticuleLayer.transform.position = Vector3.MoveTowards(topParticuleLayer.transform.position, new Vector3(topParticuleLayer.transform.position.x, YPosition+45f, topParticuleLayer.transform.position.z), speed);
            
            }
            else
            {
                
                topParticuleLayer.SetActive(false);
                //once the particule layer reaches the peak it deactivates and the inside particule layer starts to move

                
                if (topInsideParticuleLayer.transform.position.y < 15)
                {
                    topInsideParticuleLayer.transform.position = Vector3.MoveTowards(topInsideParticuleLayer.transform.position, new Vector3(topInsideParticuleLayer.transform.position.x, YPosition+45f, topInsideParticuleLayer.transform.position.z), speed);
            
                }
                else
                {
                    
                    //finally the inside particule layer deactivate
                    topInsideParticuleLayer.SetActive(false);
                    setAnimationHasEnded(true);
                
                
            
                }
            
            }

        }
        
 
        
    }
}
