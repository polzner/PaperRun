using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDamagedAnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private Coroutine _currentCoroutine;

    public void Play(float delay)
    {
        StopCurrentCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(PlayDamagedAnimation(delay));
    }

    private IEnumerator PlayDamagedAnimation(float time)
    {
        _animator.SetBool("Damaged", true);
        yield return new WaitForSeconds(time);
        _animator.SetBool("Damaged", false);
    }

    private void StopCurrentCoroutine(Coroutine coroutine)
    {
        if (_currentCoroutine != null)
            StopCoroutine(coroutine);
    }
}
