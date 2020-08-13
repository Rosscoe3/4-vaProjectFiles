using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : MonoBehaviour
{
    // Update is called once per frame
    Camera cam;

    public bool canRotate;

    public GameObject slider;
    public float rotateXSpeed;
    public float rotateYSpeed;
    public float minFov, maxFov;
    public float sensitivity = 10f;
    public Transform target;
    bool mouseClickjudge = false;
    bool sliderIsMoving = false;

    private void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    void Update()
    {



        //Debug.Log(cam.rect.width);

        if (cam.rect.width >= 1 && !sliderIsMoving)
        {
            float fov = cam.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * -1 * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            cam.fieldOfView = fov;

            if (Input.GetMouseButtonDown(0))
            {
                mouseClickjudge = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                mouseClickjudge = false;
            }

            if (mouseClickjudge)
            {
                transform.RotateAround(Vector3.zero, Vector3.up, Input.GetAxis("Mouse X") * rotateXSpeed * Time.deltaTime);
            }
        }
        else if (!sliderIsMoving && canRotate)
        {
            transform.RotateAround(Vector3.zero, Vector3.up, 5 * Time.deltaTime);
        }

        transform.LookAt(target);

    }

    public void SliderMove()
    {
        sliderIsMoving = true;
    }

    public void SliderStop()
    {
        sliderIsMoving = false;
    }
}
