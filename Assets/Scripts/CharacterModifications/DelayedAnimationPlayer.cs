using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedAnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private Coroutine _currentCoroutine;

    private string _animatorParameter;

    public void Play(float delay, string parameter)
    {
        _animatorParameter = parameter;
        StopCurrentCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(PlayDamagedAnimation(delay));
    }

    public void Stop()
    {
        StopCurrentCoroutine(_currentCoroutine);
        _animator.SetBool(_animatorParameter, false);
    }

    private IEnumerator PlayDamagedAnimation(float time)
    {
        _animator.SetBool(_animatorParameter, true);
        yield return new WaitForSeconds(time);
        _animator.SetBool(_animatorParameter, false);
    }

    private void StopCurrentCoroutine(Coroutine coroutine)
    {
        if (_currentCoroutine != null)
            StopCoroutine(coroutine);
    }
}
