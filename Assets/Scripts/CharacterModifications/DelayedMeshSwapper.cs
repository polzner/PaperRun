using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DelayedMeshSwapper : MonoBehaviour
{
    [SerializeField] private List<CharacterMesh> _allMeshes;
    [SerializeField] private CharacterMesh _defaultMesh;

    private Coroutine _currentCoroutine;

    public void SwapMesh<T>(float delay) where T : CharacterMesh
    {
        StopCurrentCoroutine(_currentCoroutine);
        CharacterMesh swapMesh = _allMeshes.FirstOrDefault(mesh => mesh is T);
        _currentCoroutine = StartCoroutine(SwapMeshRoutine(_defaultMesh, swapMesh, delay));
    }

    private IEnumerator SwapMeshRoutine(CharacterMesh defaultMesh, CharacterMesh swapMesh, float delay)
    {
        defaultMesh.gameObject.SetActive(false);
        swapMesh.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        defaultMesh.gameObject.SetActive(true);
        swapMesh.gameObject.SetActive(false);
    }

    private void StopCurrentCoroutine(Coroutine coroutine)
    {
        if (_currentCoroutine != null)
            StopCoroutine(coroutine);
    }
}
