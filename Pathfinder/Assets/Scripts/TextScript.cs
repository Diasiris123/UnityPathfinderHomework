using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public TextMeshProUGUI textForArissa;
    void Start()
    {
        GameManager.PlayerReachedDestination += On;
        GameManager.PlayerIsOnTheWay += On;
        GameManager.PlayerIsHalfwayThrough += On;
    }
    private void On(string text)
    {
        textForArissa.text = text;
    }
}
