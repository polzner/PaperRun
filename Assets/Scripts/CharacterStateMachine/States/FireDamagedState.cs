using System;
using System.Collections;
using UnityEngine;

class FireDamagedState : BaseState
{
    [SerializeField] private CharacterMover _mover;
    [SerializeField] private DelayedColorSwapper _colorSwapper;
    [SerializeField] private DelayedAnimationPlayer _damagedAnimationPlayer;
    [SerializeField] private DelayedEffectPlayer _burningEffectPlayer;
    [SerializeField] private float _delay;

    public override void Begin()
    {
        _colorSwapper.Swap();
        _mover.SlowDown(_delay);
        _damagedAnimationPlayer.Play(_delay, AnimatorPaperCharacter.Params.Damaged);
        _burningEffectPlayer.Play(_delay);
    }

    public override void Stop()
    {
        _damagedAnimationPlayer.Stop();
    }
}
