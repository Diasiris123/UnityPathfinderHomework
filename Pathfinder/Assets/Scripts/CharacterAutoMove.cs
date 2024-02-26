using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class CharacterAutoMove : MonoBehaviour
{
    private const string speedAnimatorParameter = "Speed";
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform destination;
    [SerializeField] TextMeshProUGUI finishText;
    [SerializeField] private Animator agentAnimator;

    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private float _timer = 3f;
    private bool _startTimer = false;

    void Start()
    {
        agent.SetDestination(destination.position);
        GameManager.PlayerIsOnTheWay?.Invoke("Arissa is on the way to her destination!");
        StartCoroutine("Seconds");
    }
    private IEnumerator Seconds()
    {
        yield return new WaitForSeconds(7);
        GameManager.PlayerIsHalfwayThrough?.Invoke("Arissa is halfway through!");
    }
    private void Update()
    {
        agentAnimator.SetFloat(speedAnimatorParameter, agent.velocity.magnitude);


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
        GameManager.PlayerReachedDestination?.Invoke("The Clone has reached its destination!");
        finishText.enabled = true;
    }
}
