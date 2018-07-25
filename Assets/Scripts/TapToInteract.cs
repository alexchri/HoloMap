using System;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class TapToInteract : MonoBehaviour, IInputClickHandler
{
    public GameObject Cursor;

    public bool clicked = false;
    public float rotationspeed = 1.0f;
    public Sprite[] Icons;

    public void Awake()
    {
        //Load all sprites from the menu button folder in Sprites Folder
        object[] loadedIcons = Resources.LoadAll("MenuButton", typeof(Sprite));
        Icons = new Sprite[loadedIcons.Length];
        for(int x = 0; x < loadedIcons.Length; ++x)
        {
            Icons[x] = (Sprite)loadedIcons[x];
        }

        //By default set all children items of menu to inactive
        ToggleChildren(false);
    }

    public void Update()
    {
        //Always have this UI button face the user
        //this.transform.LookAt(Camera.main.transform.position, Camera.main.transform.up);
        var neededrotation = Quaternion.LookRotation(Camera.main.transform.position - this.transform.position);
        Quaternion.Slerp(this.transform.rotation, neededrotation, Time.deltaTime * rotationspeed);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(clicked == false)
        {
            clicked = true;
            SwitchSprites(0);
            ToggleChildren(true);
        }
        else if(clicked == true)
        {
            clicked = false;
            SwitchSprites(1);
            ToggleChildren(false);
        }
    }

    private void SwitchSprites(int id)
    {
        switch(id)
        {
            case 0:
                //switch to up arrows
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Icons[0]; 
                break;
            case 1:
                //switch to down arrows
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Icons[1];
                break;
            default:
                //throw exception here since impossible case
                break;
        }
    }

    private void ToggleChildren(bool enable)
    {
        if(enable == true)
        {
            foreach(Transform child in this.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else if (enable == false)
        {
            foreach (Transform child in this.transform)
            {
                if (child.gameObject.name == "Manager")
                {
                    continue;
                }
                child.gameObject.SetActive(false);
            }
        }
    }
}
