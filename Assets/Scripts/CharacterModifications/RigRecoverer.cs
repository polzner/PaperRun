using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigRecoverer : MonoBehaviour
{
    [SerializeField] private Rig _rig;
    [Range(0,1)] [SerializeField] private float _recoveryRigWeightSpeed = 0.5f;
    private Coroutine _currentCoroutine;

    public Rig Rig => _rig;

    public void Recover()
    {
        StopCurrentCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(TakeNormalRigPosition(_rig));
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
