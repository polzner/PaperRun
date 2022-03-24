using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DelayedAnimatorEnabler : MonoBehaviour
{
    [SerializeField] private List<Animator> _animators;
    [SerializeField] private float _delay;

    private void Start()
    {
        float currentDelay = 0;

        foreach (Animator animator in _animators)
        {
            animator.SetFloat("Delay", currentDelay);
            currentDelay += _delay;
        }
    }
}
