using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action<string> PlayerReachedDestination;
    public static Action<string> PlayerIsOnTheWay;
    public static Action<string> PlayerIsHalfwayThrough;
}
