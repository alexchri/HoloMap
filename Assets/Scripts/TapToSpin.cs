using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;

public class TapToSpin : MonoBehaviour, IInputClickHandler {

    public bool spin = false;
    public int degree = 5;

	// Use this for initialization
	public void OnInputClicked(InputClickedEventData eventData)
    {
        string name = this.gameObject.name;
        
        if(spin == true)
        {
            spin = false;
        }
        else if(spin == false)
        {
            spin = true;
        }
    }

    private void Update()
    {
        if(spin)
        {
            this.gameObject.transform.Rotate(Vector3.right * degree * Time.deltaTime);
        }
    }
}
