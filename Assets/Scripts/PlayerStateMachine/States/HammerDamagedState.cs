using System;
using System.Collections;
using UnityEngine.Animations.Rigging;
using UnityEngine;

class HammerDamagedState : BaseDamagedState
{
    [SerializeField] private CharacterMover _mover;
    [SerializeField] private DelayedDamagedAnimationPlayer _damagedAnimationPlayer;
    [SerializeField] private RigRecoverer _rigRecoverer;
    [SerializeField] private Rig _hammerDamagedRig;

    public override void Begin()
    {
        _hammerDamagedRig.weight = 1f;
        _rigRecoverer.Recover(_hammerDamagedRig);
        _damagedAnimationPlayer.Play(Delay);
        _mover.SlowDown(Delay);
    }

    public override void Stop()
    {
    }
}
