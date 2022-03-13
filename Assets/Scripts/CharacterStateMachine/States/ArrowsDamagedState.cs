using System;
using System.Collections;
using UnityEngine;

class ArrowsDamagedState : BaseState
{
    [SerializeField] private CharacterMover _mover;
    [SerializeField] private DelayedAnimationPlayer _animationPlayer;
    [SerializeField] private DelayedMeshSwapper _meshSwapper;
    [SerializeField] private DelayedEffectPlayer _paperEffectPlayer;
    [SerializeField] private float _delay;

    public override void Begin()
    {
        _mover.SlowDown(_delay);
        _paperEffectPlayer.Play(_delay);
        _meshSwapper.SwapMesh<ArrowDamagedMesh>(_delay);
        _animationPlayer.Play(_delay, AnimatorPaperCharacter.Params.Damaged);
    }

    public override void Stop()
    {
        _animationPlayer.Stop();
        _meshSwapper.Stop();
    }
}
