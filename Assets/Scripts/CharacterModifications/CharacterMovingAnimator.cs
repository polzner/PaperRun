using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovingAnimator : MonoBehaviour
{
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private CharacterMover _mover;

    private void OnEnable()
    {
        _mover.Moved += OnMoved;
    }

    private void OnDisable()
    {
        _mover.Moved -= OnMoved;
    }

    private void OnMoved(float speed)
    {
        _characterAnimator.SetFloat(AnimatorPaperCharacter.Params.Speed, speed);
    }
}
