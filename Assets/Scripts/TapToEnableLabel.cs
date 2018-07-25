using UnityEngine;
using UnityEngine.UI;
using System;
using HoloToolkit.Unity.InputModule;

public class TapToEnableLabel : MonoBehaviour, IInputClickHandler {

    public GameObject Manager;
    public GameObject LabelScript;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Manager.GetComponent<MenuPublicVariables>().SelectOption(LabelScript);
    }
}
