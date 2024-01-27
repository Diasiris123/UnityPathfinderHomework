using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSript : MonoBehaviour
{
    [SerializeField] private CanvasGroup CanvasGroup;
    public float _timer = 3f;
    private bool _startTimer = false;

    void Update()
    {
        if (CanvasGroup.alpha <= 1)
        {
            FadeIn();
            if (CanvasGroup.alpha >= 1 ) 
                _startTimer = true;
        }

        if (_startTimer)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
                _startTimer = false;
        }

        if (_timer <= 0 )
        {
            FadeOut();
        }
    }

    void FadeOut()
    {
        CanvasGroup.alpha -= Time.deltaTime;
    }

    void FadeIn()
    {
        CanvasGroup.alpha += (Time.deltaTime * 0.25f);
    }
}
