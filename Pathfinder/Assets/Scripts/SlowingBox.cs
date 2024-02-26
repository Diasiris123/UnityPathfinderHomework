using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlowingBox : MonoBehaviour
{
    public static SlowingBox instance;
    public GameObject SlowArea;

    public UnityEvent SlowStateEvent;
    public UnityEvent ReturnDefaultEvent;

    private void OnEnable()
    {
        instance = this;
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SlowStateEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        ReturnDefaultEvent.Invoke();
    }
}
