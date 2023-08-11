using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitOpenParticule : AbstractAnimationAction
{

    //this script take a list of top shells and will move them up one by one and disable them once they reach a certain position
    //In addition it also activates the center orange layer which was previously disabled to enhance performance
    [SerializeField] private GameObject topOuterLayer;
    
    [SerializeField] private GameObject bottomParticuleLayer;
    
    [SerializeField] private GameObject bottomInsideParticuleLayer;
    
    [SerializeField] private GameObject topParticuleLayer;
    
    [SerializeField] private GameObject topInsideParticuleLayer;

    [SerializeField] private Vector3 topOuterLayerPosition = new Vector3();

    [SerializeField] private float YPosition;
    
    [SerializeField] private float speed;

    [SerializeField] private int objectListIndex;

    [SerializeField] private bool activateAll;

    [SerializeField] private List<GameObject> objectsToMoveUp;


    // Start is called before the first frame update
    void Start()
    {
        
        YPosition = topOuterLayer.transform.position.y;
        activateAll = false;
        objectListIndex = 0;



    }

    // Update is called once per frame

    public override void execute(float speedMultiplier, bool isBackward)
    {

        if (activateAll == false)
        {

            foreach (var ob in objectsToMoveUp)
            {
                ob.SetActive(true);
            }
            topParticuleLayer.SetActive(true);
            topInsideParticuleLayer.SetActive(true);
            bottomParticuleLayer.SetActive(true);
            bottomInsideParticuleLayer.SetActive(true);
            activateAll = true;
        }
        speed = 0.35f;
        speed *=  speedMultiplier;
        topOuterLayerPosition = objectsToMoveUp[objectListIndex].transform.position;
        
        //moving the top shell
        objectsToMoveUp[objectListIndex].transform.position = Vector3.MoveTowards(topOuterLayerPosition, new Vector3(topOuterLayerPosition.x, YPosition+45f, topOuterLayerPosition.z), speed);

        //if the shell's position surpasses 15 it will disable and the code will move on to the next shell to move.
        if (objectsToMoveUp[objectListIndex].transform.position.y > 15)
        {
            objectsToMoveUp[objectListIndex].SetActive(false);
            objectListIndex++;
        }

        //ending the animation 
        if (objectListIndex == objectsToMoveUp.Count)
        {
            setAnimationHasEnded(true);
        }
       
        
        //same code but different logic
 
        /*speed = 0.35f;
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

        }*/
        
 
        
    }
}
