using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BladeDamagedState : BaseState
{
    [SerializeField] private CharacterSlicer _slicer;
    [SerializeField] private RigRecoverer _rigRecoverer;
    [Range(0, 1)] [SerializeField] private float _canSliceValue;
    [SerializeField] private float _recoverDelay;
    [SerializeField] private DelayedMeshSwapper _meshSwapper;
    [SerializeField] private DelayedAnimationPlayer _damagedAnimationPlayer;
    [SerializeField] private CharacterMover _mover;
    [SerializeField] private DelayedEffectPlayer _effectPlayer;
    [SerializeField] private float _delay;

    private Coroutine _currentCoroutine;
    private bool CanSlice => _rigRecoverer.Rig.weight <= _canSliceValue;

    public override void Begin()
    {
        if (CanSlice)
        {
            StopCurrentCoroutine(_currentCoroutine);
            _meshSwapper.SwapMesh<LowerBodyMesh>(_recoverDelay);
            _slicer.Slice();

            TakeDamagedRigPosittion(_rigRecoverer.Rig);

            _effectPlayer.Play(_delay);
            _mover.SlowDown(_delay);
            _damagedAnimationPlayer.Play(_delay, AnimatorPaperCharacter.Params.Damaged);
            _currentCoroutine = StartCoroutine(RecoverRigWithDelay(_recoverDelay));
        }
    }

    public override void Stop()
    {
        _damagedAnimationPlayer.Stop();
        _meshSwapper.Stop();
    }

    private void TakeDamagedRigPosittion(Rig rig)
    {
        if (_rigRecoverer.Rig.weight != 0)
            _rigRecoverer.Rig.weight = 0;

        _rigRecoverer.Rig.weight = 1f;
    }

    private IEnumerator RecoverRigWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _rigRecoverer.Recover();
    }

    private void StopCurrentCoroutine(Coroutine coroutine)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }
}
