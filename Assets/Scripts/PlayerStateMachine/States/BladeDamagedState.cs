using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BladeDamagedState : BaseDamagedState
{
    [SerializeField] private CharacterSlicer _slicer;
    [SerializeField] private RigRecoverer _rigRecoverer;
    [SerializeField] private Rig _damagedRig;
    [Range(0, 1)] [SerializeField] private float _canSliceValue;
    [SerializeField] private float _recoverDelay;
    [SerializeField] private DelayedMeshSwapper _meshSwapper;
    [SerializeField] private DelayedDamagedAnimationPlayer _damagedAnimationPlayer;
    [SerializeField] private CharacterMover _mover;
    [SerializeField] private DelayedEffectPlayer _effectPlayer;
    [SerializeField] private ParticleSystem _paperDamagedEffect;

    private Coroutine _currentCoroutine;
    private bool CanSlice => _damagedRig.weight <= _canSliceValue;

    public override void Begin()
    {
        if (CanSlice)
        {
            StopCurrentCoroutine(_currentCoroutine);
            _slicer.Slice();
            _effectPlayer.Play(Delay, _paperDamagedEffect);
            _meshSwapper.SwapMesh<LowerBodyMesh>(_recoverDelay);
            _mover.SlowDown(Delay);
            _damagedAnimationPlayer.Play(Delay);
            TakeDefaultRigPosition();
            _currentCoroutine = StartCoroutine(RecoverRigWithDelay(_recoverDelay));
        }
    }

    public override void Stop()
    {
        
    }

    private void TakeDefaultRigPosition()
    {
        _rigRecoverer.Stop();
        _damagedRig.weight = 1f;
    }

    private IEnumerator RecoverRigWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _rigRecoverer.Recover(_damagedRig);
    }

    private void StopCurrentCoroutine(Coroutine coroutine)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }
}
