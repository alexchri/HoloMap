using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPublicVariables : MonoBehaviour {

    public GameObject Cursor;
    public GameObject Option;

    public void Awake()
    {
        Option = null;
    }

    public void SelectOption(GameObject newOption)
    {
        if(Option == newOption)
        {
            Option.SetActive(false);
            Option = null;
            //highlight
            return;
        }

        if(Option != null && Option != newOption)
        {
            Option.SetActive(false);
            //remove highlight from previous
            Option = newOption;
            //highlight new option
            Option.SetActive(true);
        }

        if(Option == null && Option != newOption)
        {
            Option = newOption;
            //highlight new option
            Option.SetActive(true);
        }

        
    }
}
