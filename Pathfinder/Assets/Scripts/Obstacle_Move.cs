using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Obstacle_Move : MonoBehaviour
{
    [SerializeField] Transform obstacle;
    bool _switchDirection = false;
    void Update()
    {
        if(!_switchDirection)
        {
            MoveForward();
        }
        else
        {
            MoveBackward();
        }

    }

    void MoveForward()
    {
        Vector3 direction = new Vector3(0, 0, transform.position.z);
        transform.Translate(direction * Time.deltaTime * 0.25f);

        if(transform.position.z >= 7.2)
            _switchDirection = true;
    }

    void MoveBackward()
    {
        Vector3 direction = new Vector3(0, 0, -transform.position.z);
        transform.Translate(direction * Time.deltaTime * 0.25f);

        if (transform.position.z <= 3.7)
            _switchDirection = false;
    }
}
