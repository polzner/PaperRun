using System;
using System.Collections;
using UnityEngine;

class FireDamagedState : BaseDamagedState
{
    [SerializeField] private CharacterMover _mover;
    [SerializeField] private DelayedDamagedAnimationPlayer _damagedAnimationPlayer;
    [SerializeField] private DelayedEffectPlayer _effectPlayer;
    [SerializeField] private ParticleSystem _burningEffect;

    public override void Begin()
    {
        _mover.SlowDown(Delay);
        _damagedAnimationPlayer.Play(Delay);
        _effectPlayer.Play(Delay,_burningEffect);
    }

    public override void Stop()
    {

    }
}
