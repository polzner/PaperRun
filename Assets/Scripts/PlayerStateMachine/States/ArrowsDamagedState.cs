using System;
using System.Collections;
using UnityEngine;

class ArrowsDamagedState : BaseDamagedState
{
    [SerializeField] private CharacterMover _mover;
    [SerializeField] private DelayedDamagedAnimationPlayer _damagedAnimationPlayer;
    [SerializeField] private DelayedMeshSwapper _meshSwapper;
    [SerializeField] private DelayedEffectPlayer _effectPlayer;
    [SerializeField] private ParticleSystem _paperDamagedEffect;

    public override void Begin()
    {
        _mover.SlowDown(Delay);
        _damagedAnimationPlayer.Play(Delay);
        _effectPlayer.Play(Delay, _paperDamagedEffect);
        _meshSwapper.SwapMesh<ArrowDamagedMesh>(Delay);
    }

    public override void Stop()
    {
    }
}
