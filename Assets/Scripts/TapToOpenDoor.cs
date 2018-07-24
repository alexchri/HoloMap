using System;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class TapToOpenDoor : MonoBehaviour, IInputClickHandler
{
    public bool open = false;
    public bool active = false;
    public float speed = 1.0f;
    public float openAngle = 90.0f;
    private float angleError = 0.5f;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private Vector3 zero;

    public void Awake()
    {
        //if inactive & closed, save the values of startrotation & endrotation
        if (active == false && open == false)
        {
            zero = this.transform.forward;
            startRotation = this.transform.rotation;
            this.transform.RotateAround(transform.position, transform.up, openAngle);
            endRotation = this.transform.rotation;
            this.transform.rotation = startRotation;
        }
    }
    public void OnInputClicked(InputClickedEventData eventData)
    {
        
        //User wants to interact with door
        if(open == false)
        {
            open = true;
        }
        else if(open == true)
        {
            open = false;
        }

        //Action is being performed
        active = true;
    }

    public void Update()
    {
        //if user interacted with the door
        if(active == true)
        {
            //open the door
            if(open == true)
            {
                OpenDoor();
            }
            //close the door
            else if(open == false)
            {
                CloseDoor();
            }
        }
    }

    private float previousAngle = 0.0f;
    private bool valid = false;
    private bool closeDoor = true;
    private void CloseDoor()
    {
        var forward = this.gameObject.transform.forward; 
        float rotationAngle = Vector3.Angle(zero, forward);
        float difference = rotationAngle - previousAngle;
        if (valid)
        {
            if(difference > 0.0f)
            {
                closeDoor = false;
            }
        }
        previousAngle = rotationAngle;
        valid = true;
        if (closeDoor)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * speed * -1.0f * openAngle);
        }
        else {
            this.transform.rotation = startRotation;
            active = false;
            valid = false;
            closeDoor = true;
        }
    }

    private void OpenDoor()
    {
        var forward = this.gameObject.transform.forward;
        float rotationAngle = Vector3.Angle(zero, forward);
        if (rotationAngle < openAngle)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * speed * openAngle);
        }
        else
        {
            this.transform.rotation = endRotation;
            active = false;
        }
    }
}
