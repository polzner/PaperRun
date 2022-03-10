using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovingAnimator : MonoBehaviour
{
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private CharacterInput _input;

    private void OnEnable()
    {
        _input.Moved += OnMoved;
    }

    private void OnDisable()
    {
        _input.Moved -= OnMoved;
    }

    private void OnMoved(float speed)
    {
        _characterAnimator.SetFloat("Speed", speed);
    }
}
