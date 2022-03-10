using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedEffectPlayer : MonoBehaviour
{
    private Coroutine _currentCoroutine;

    public void Play(float delay, ParticleSystem effect)
    {
        StopCurrentCoroutine(_currentCoroutine);
        effect.Stop();
        _currentCoroutine = StartCoroutine(PlayEffect(delay, effect));
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
