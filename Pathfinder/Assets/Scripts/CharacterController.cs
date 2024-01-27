using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent Arisa;
    [SerializeField] private Transform targetDestination;
    RaycastHit hit;

    private void Start()
    {
        Arisa.SetDestination(targetDestination.position);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Arisa.SetDestination(hit.point);
            }
        }
    }
}