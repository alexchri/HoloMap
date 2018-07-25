using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelTrigger : MonoBehaviour {

    public void OnEnable()
    {
        this.gameObject.GetComponentInParent<MenuPublicVariables>().Cursor.GetComponent<Label>().enabled = true;
    }

    public void OnDisable()
    {
        this.gameObject.GetComponentInParent<MenuPublicVariables>().Cursor.GetComponent<Label>().enabled = false;
    }
}
