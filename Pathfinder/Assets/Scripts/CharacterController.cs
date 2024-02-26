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

    private void Start()
    {
        Arisa.SetDestination(targetDestination.position);
    }
    void Update()
    {
        agentAnimator.SetFloat(speedAnimatorParameter, Arisa.velocity.magnitude);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Arisa.SetDestination(hit.point);
            }
        }
    }
}