using System;
using System.Collections;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ProjectOnSurface _projectOnSurface;
    [SerializeField] private float _startSpeed = 8;
    [SerializeField] private float _slowdownOffset = 5;

    private float _currentSpeed;
    private Coroutine _currentCoroutine;

    private void Start()
    {
        _currentSpeed = _startSpeed;
    }

    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = _projectOnSurface.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (_currentSpeed * Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    public void SlowDown(float delay)
    {
        if(_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentSpeed = _startSpeed;
        _currentCoroutine = StartCoroutine(Slow(_slowdownOffset, delay));
    }

    private IEnumerator Slow(float offset, float delay)
    {
        _currentSpeed -= offset;
        yield return new WaitForSeconds(delay);
        _currentSpeed = _startSpeed;
    }
}
