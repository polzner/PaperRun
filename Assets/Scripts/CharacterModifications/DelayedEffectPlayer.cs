using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedEffectPlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    private Coroutine _currentCoroutine;

    public void Play(float delay)
    {
        StopCurrentCoroutine(_currentCoroutine);
        _effect.Stop();
        _currentCoroutine = StartCoroutine(PlayEffect(delay, _effect));
    }

    private IEnumerator PlayEffect(float delay, ParticleSystem effect)
    {
        effect.Play();
        yield return new WaitForSeconds(delay);
        effect.Stop();
    }

    private void StopCurrentCoroutine(Coroutine coroutine)
    {
        if (_currentCoroutine != null)
            StopCoroutine(coroutine);
    }
}
