using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovingAnimator : MonoBehaviour
{
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private PlayerInput _input;

    private void OnEnable()
    {
        _input.Moved += OnMoved;
        _input.MovingStopped += OnMovingStopped;
    }

    private void OnDisable()
    {
        _input.Moved -= OnMoved;
        _input.MovingStopped -= OnMovingStopped;
    }

    private void OnMoved(float speed)
    {
        _characterAnimator.SetFloat("Speed", speed);
    }

    private void OnMovingStopped()
    {
        _characterAnimator.SetFloat("Speed", 0);
    }
}
