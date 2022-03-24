using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedColorSwapper : MonoBehaviour
{
    [SerializeField] private Material _currentMaterial;
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _colorDelay;
    [SerializeField] private float _recoverColorDelay;

    private Coroutine _currentCoroutine;
    private Color _defaultColor;

    private void Start()
    {
        _defaultColor = _currentMaterial.color;
    }

    public void Swap()
    {
        StopCurrentCoroutine(_currentCoroutine);
        _currentMaterial.color = _targetColor;
        _currentCoroutine = StartCoroutine(SwapColorRoutine(_currentMaterial, _defaultColor, _colorDelay, _recoverColorDelay));
    }

    private IEnumerator SwapColorRoutine(Material material, Color defaultColor, float startDelay, float recoverDelay)
    {
        float currentTime = 0;
        Color startColor = material.color;

        yield return new WaitForSeconds(startDelay);

        while (currentTime <= recoverDelay)
        {
            material.color = Color.Lerp(startColor, defaultColor, currentTime / recoverDelay);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }

    private void StopCurrentCoroutine(Coroutine coroutine)
    {
        if (_currentCoroutine != null)
            StopCoroutine(coroutine);
    }
}
