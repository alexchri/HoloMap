using System;
using UnityEngine.UI;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Label : MonoBehaviour, IHoldHandler
{
    public float speed = 2.0f;
    public GameObject pinprefab;
    public GameObject pininstance;
    public GameObject Cursor;

    public void OnHoldStarted(HoldEventData eventData)
    {
        //Create pin object
        pininstance = Instantiate(pinprefab, Cursor.gameObject.transform.position, Cursor.gameObject.transform.rotation);
    }

    public void OnHoldCompleted(HoldEventData eventData)
    {
        Destroy(pininstance);
        pininstance = null;
    }

    public void OnHoldCanceled(HoldEventData eventData)
    {
        Destroy(pininstance);
        pininstance = null;
    }

    public void Update()
    {
        pininstance.transform.position = Vector3.Lerp(pininstance.transform.position, Cursor.transform.position, Time.deltaTime * speed);
    }
}
