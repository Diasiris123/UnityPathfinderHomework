using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractEventManager : MonoBehaviour
{
    public delegate void AreaInteract(bool state);
    public static event AreaInteract OnInteracted;

    private void OnTriggerEnter(Collider other)
    {
        OnInteracted(true);
    }

    private void OnTriggerExit(Collider other)
    {
        OnInteracted(false);
    }
}
