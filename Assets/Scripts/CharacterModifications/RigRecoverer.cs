using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigRecoverer : MonoBehaviour
{
    [SerializeField] private float _recoveryRigWeightSpeed;
    private Coroutine _currentCoroutine;

    public void Recover(Rig rig)
    {
        StopCurrentCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(TakeNormalRigPosition(rig));
    }

    public void Stop()
    {
        StopCurrentCoroutine(_currentCoroutine);
    }

    private IEnumerator TakeNormalRigPosition(Rig rig)
    {
        while (rig.weight != 0)
        {
            rig.weight = Mathf.MoveTowards(rig.weight, 0f, Time.deltaTime * _recoveryRigWeightSpeed);
            yield return null;
        }
    }

    private void StopCurrentCoroutine(Coroutine coroutine)
    {
        if (_currentCoroutine != null)
            StopCoroutine(coroutine);
    }
}
