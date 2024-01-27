using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAutoMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform destination;
    [SerializeField] TextMeshProUGUI finishText;

    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private float _timer = 3f;
    private bool _startTimer = false;

    void Start()
    {
        agent.SetDestination(destination.position);  
    }

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders);

        if (_colliders[1] != null )
        {
            if (_colliders[1].tag == "Interactable")
            {
                SetText();
                _startTimer = true;
            }
        }

        if (_startTimer)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                finishText.enabled = false;
                _startTimer = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }

    private void SetText()
    {
        finishText.text = "The Clone has reached its destination!";
        finishText.enabled = true;
    }
}
