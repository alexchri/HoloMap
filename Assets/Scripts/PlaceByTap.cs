using System;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class PlaceByTap : MonoBehaviour, IInputClickHandler
{
    protected MoveByGaze GazeMover;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (this.GetComponent<MoveByGaze>().IsActive == false)
        {
            this.GetComponent<MoveByGaze>().IsActive = true;
        }
        else if (this.GetComponent<MoveByGaze>().IsActive == true)
        {
            this.GetComponent<MoveByGaze>().IsActive = false;
        }
    }
}
