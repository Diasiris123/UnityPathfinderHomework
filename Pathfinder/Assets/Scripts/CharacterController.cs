using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    private const string speedAnimatorParameter = "Speed";
    [SerializeField] private NavMeshAgent Arisa;
    [SerializeField] private Transform targetDestination;
    [SerializeField] private Animator agentAnimator;
    RaycastHit hit;

    private bool isSlowed = false;

    private void Start()
    {
        Arisa.SetDestination(targetDestination.position);
    }

    void Update()
    {
        if(!isSlowed)
        {
            agentAnimator.SetFloat(speedAnimatorParameter, Arisa.velocity.magnitude);
        }
        else
        {
            agentAnimator.SetFloat(speedAnimatorParameter, 0);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Arisa.SetDestination(hit.point);
            }
        }
    }

    void ChangeState(bool state)
    {
        isSlowed = state;
    }

    public void OnEnable()
    {
        InteractEventManager.OnInteracted += ChangeState;
    }

    public void OnDisable()
    {
        InteractEventManager.OnInteracted -= ChangeState;
    }
}