using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollower : MonoBehaviour
{
    public PathCreator[] paths;
    public EndOfPathInstruction end;
    public GameObject water;
    int pathPicker;
    float speed;
    float startSpeed;
    float distanceTraveled;

    void Awake()
    {
        RandomPath();
        startSpeed = Random.Range(10f, 25f);
        speed = startSpeed;
    }

    void Update()
    {
        distanceTraveled += speed * Time.deltaTime;
        transform.position = paths[pathPicker].path.GetPointAtDistance(distanceTraveled, end);
        transform.rotation = paths[pathPicker].path.GetRotationAtDistance(distanceTraveled, end);

        CarInteraction(transform.position, 5);

        if (pathPicker != 1 || pathPicker != 3)
        {
            transform.rotation *= Quaternion.Euler(0, 180f, 0);
        }

        if (paths[pathPicker].path.length <= distanceTraveled)
        {
            distanceTraveled = 0f;
            RandomPath();
        }
    }

    void RandomPath()
    {
        if (water.transform.position.y > -1)
        {
            pathPicker = 2;
        }
        else
        {
            pathPicker = (int)Random.Range(0, paths.Length);
        }

        startSpeed = Random.Range(10f, 25f);
        speed = startSpeed;
    }


    void CarInteraction(Vector3 center, float radius)
    //Affects the Cars speed if it is near another car 
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.tag == "car")
            {
                Transform otherCar;
                otherCar = hitColliders[i].gameObject.transform;
                Vector3 direction = otherCar.InverseTransformPoint(transform.position);
                float distance = Vector3.Distance(otherCar.position, transform.position);

                if (direction.z > 0f)
                //if another Car is in front 
                {
                    if (hitColliders[i].gameObject.GetComponent<PathFollower>().pathPicker == 0 && pathPicker == 3 ||
                        hitColliders[i].gameObject.GetComponent<PathFollower>().pathPicker == 3 && pathPicker == 0)
                    // If two cars are traveling on paths in the opposite direction, they will not slow down
                    {
                        //print("WE ON THE SAME PATH: " + name + ", " + hitColliders[i].gameObject.name);

                        if (speed < startSpeed)
                        //Speed back up to original speed
                        {
                            speed += 0.1f;
                        }
                    }
                    else
                    // slow the car down behind it so it won't run into the back, will slow down as it gets closer to the car
                    {
                        speed = hitColliders[i].gameObject.GetComponent<PathFollower>().speed - 1f / distance;

                        if (distance < 10f)
                        {
                            speed = distance + 0.1f;
                        }
                    }
                }
                else
                // If the other car is behind it, try to speed up to original speed
                {
                    if (speed < startSpeed)
                    {
                        speed += 0.1f;
                    }
                }
            }
            i++;
        }
    }
}
