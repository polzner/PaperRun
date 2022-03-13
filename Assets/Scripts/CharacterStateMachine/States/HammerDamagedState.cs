using System;
using System.Collections;
using UnityEngine.Animations.Rigging;
using UnityEngine;

class HammerDamagedState : BaseState
{
    [SerializeField] private CharacterMover _mover;
    [SerializeField] private DelayedAnimationPlayer _damagedAnimationPlayer;
    [SerializeField] private RigRecoverer _rigRecoverer;
    [SerializeField] private float _delay;

    public override void Begin()
    {
        TakeDamagedRigPosittion(_rigRecoverer.Rig);
        _rigRecoverer.Recover();
        _damagedAnimationPlayer.Play(_delay, AnimatorPaperCharacter.Params.Damaged);
        _mover.SlowDown(_delay);
    }

    private void TakeDamagedRigPosittion(Rig rig)
    {
        if (_rigRecoverer.Rig.weight != 0)
            _rigRecoverer.Rig.weight = 0;

        _rigRecoverer.Rig.weight = 1f;
    }

    public override void Stop()
    {
        _damagedAnimationPlayer.Stop();
    }
}
