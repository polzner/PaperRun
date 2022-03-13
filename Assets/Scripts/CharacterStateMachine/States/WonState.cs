using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonState : BaseState
{
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private DelayedEffectPlayer _firecrackerEffect;
    [SerializeField] private float _delay = 5f;

    public override void Begin()
    {
        _firecrackerEffect.Play(_delay);
        _characterAnimator.SetTrigger(AnimatorPaperCharacter.Params.Finished);
    }

    public override void Stop()
    {
    }
}
