using System;
using UnityEngine;

public class StartState : BaseState
{
    [SerializeField] private Animator _characterAnimator;

    public override void Begin()
    {
        _characterAnimator.SetTrigger(AnimatorPaperCharacter.Params.Started);
    }

    public override void Stop()
    {
    }
}
