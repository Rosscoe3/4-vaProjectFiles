using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMoverScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(5f, 8f); 
    public Transform[] toPositions;
    public NavMeshAgent agent;
    public GameObject water;
    public GameObject arms;
    public MeshRenderer leftArm, rightArm, body, hat;

    public Vector3 toRotation = new Vector3(0f, 0f, 180f);
    Vector3 fromRotation; 

    bool moving = false;
    bool waterRising = false;
    bool armsRotating = false;
    float waterLevel;
    int toPositionNumb;
    Vector3 startPos; 

    private void Start()
    {
        toPositionNumb = (int)Random.Range(0, toPositions.Length);
        agent.speed = Random.Range(speed.x, speed.y);
        startPos = gameObject.transform.position;
        fromRotation = arms.transform.rotation.eulerAngles;

        leftArm.enabled = true;
        rightArm.enabled = true;
        body.enabled = true;
        hat.enabled = true;
    }

    void Update()
    {
        //If the water position is greater than its current position, and its not moving, let the arms rotate and make it start moving
        if (water.gameObject.transform.position.y >= transform.position.y - transform.localScale.y * 3 && !moving)
        {
            //Debug.Log("ITS MOVIN!");
            moving = true;
            armsRotating = true;
            waterRising = true;
            waterLevel = water.gameObject.transform.position.y; 
        }

        //If the water position is lower than it was when it left, it will move the player back to its original position
        if (water.gameObject.transform.position.y <= waterLevel - 1f)
        {
            waterRising = false;
            armsRotating = true;
            moving = true;

            leftArm.enabled = true;
            rightArm.enabled = true;
            body.enabled = true;
            hat.enabled = true;
        }

        if (moving)
        {
            if (waterRising)
            {
                agent.SetDestination(toPositions[toPositionNumb].position);

                if (armsRotating)
                {
                    if (Vector3.Distance(arms.transform.eulerAngles, toRotation) > 0.01f)
                    {
                        arms.transform.eulerAngles = Vector3.Lerp(arms.transform.rotation.eulerAngles, toRotation, 4 * Time.deltaTime);
                    }
                    else
                    {
                        arms.transform.eulerAngles = toRotation;
                        armsRotating = false;
                    }
                }
            }
            else
            {
                agent.SetDestination(startPos);
                //LeanTween.rotateZ(arms, 0f, 1f).setOnCompleteParam(armsRotating = true);

                if (armsRotating)
                {
                    if (Vector3.Distance(arms.transform.eulerAngles, toRotation) > 0.01f)
                    {
                        arms.transform.eulerAngles = Vector3.Lerp(arms.transform.rotation.eulerAngles, fromRotation, 4 * Time.deltaTime);
                    }
                    else
                    {
                        arms.transform.eulerAngles = toRotation;
                        armsRotating = false;
                    }
                }
            }

            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        //REACHED THE END OF THE PATH
                        moving = false;
                        armsRotating = true;

                        if (waterRising)
                        {
                            leftArm.enabled = false;
                            rightArm.enabled = false;
                            body.enabled = false;
                            hat.enabled = false;
                        }
                    }
                }
            }
        }

    }
}
