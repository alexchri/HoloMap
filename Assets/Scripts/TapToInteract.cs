using System;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class TapToInteract : MonoBehaviour, IInputClickHandler
{
    public bool clicked = false;
    private Sprite[] Icons;

    public void Awake()
    {
        //Load all sprites from the menu button folder in Sprites Folder
        object[] loadedIcons = Resources.LoadAll("Sprites/MenuButton", typeof(Sprite));
        Icons = new Sprite[loadedIcons.Length];
        for(int x = 0; x < loadedIcons.Length; ++x)
        {
            Icons[x] = (Sprite)loadedIcons[x];
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(clicked == false)
        {
            clicked = true;
            SwitchSprites(0);
        }
        else if(clicked == true)
        {
            clicked = false;
            SwitchSprites(1);
        }
    }

    private void SwitchSprites(int id)
    {
        switch(id)
        {
            case 0:
                //switch to up arrows
                this.gameObject.GetComponent<Button>().image.sprite = Icons[0]; 
                break;
            case 1:
                //switch to down arrows
                this.gameObject.GetComponent<Button>().image.sprite = Icons[1];
                break;
            default:
                //throw exception here since impossible case
                break;
        }
    }
}
