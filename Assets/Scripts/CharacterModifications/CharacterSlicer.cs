using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterSlicer : MonoBehaviour
{
    [SerializeField] private Rigidbody _upperPartOfBody;
    [SerializeField] private Transform _forcePosition;
    [SerializeField] private Transform _forceRotator;
    [SerializeField] private int _rotationAngleOffset;
    [SerializeField] private float _forceMultiplyer;
    [SerializeField] private float _disableTime;

    private Vector3 _defaultBodyPosition;
    private Coroutine _currentCoroutine;

    private void Start()
    {
        _defaultBodyPosition = _upperPartOfBody.transform.localPosition;
    }

    public void Slice()
    {
        ChangeRandomForceRotation(_rotationAngleOffset, _forceRotator);
        StopCurrentCoroutine(_currentCoroutine);
        ResetPosition(_upperPartOfBody);
        _upperPartOfBody.gameObject.SetActive(false);
        _currentCoroutine = StartCoroutine(PushObject(_upperPartOfBody, _forcePosition.up * _forceMultiplyer,
                _forcePosition.position, _disableTime));
        
    }

    private IEnumerator PushObject(Rigidbody rigidbody, Vector3 force, Vector3 forcePosition, float disableTime)
    {
        rigidbody.gameObject.SetActive(true);
        rigidbody.AddForceAtPosition(force, forcePosition, ForceMode.VelocityChange);
        yield return new WaitForSeconds(disableTime);
        rigidbody.gameObject.SetActive(false);
        ResetPosition(rigidbody);   
    }

    private void ResetPosition(Rigidbody rigidbody)
    {
        rigidbody.transform.localPosition = _defaultBodyPosition;
        rigidbody.transform.localRotation = Quaternion.identity;
    }

    private void ChangeRandomForceRotation(int angleOffset, Transform forceRotator)
    {
        forceRotator.rotation = Quaternion.Euler(Vector3.up * Random.Range(-angleOffset, angleOffset));
    }

    private void StopCurrentCoroutine(Coroutine coroutine)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }
}
