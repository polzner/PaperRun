using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotInput : CharacterInput
{
    public override event Action<float> Moved;

    private Vector3 _currentDirection;

    private void Start()
    {
        StartCoroutine(MovingRoutine());
    }

    private void Update()
    {
        Mover.Move(_currentDirection);
    }

    private IEnumerator MovingRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 2));
            _currentDirection = new Vector3(0, 0, UnityEngine.Random.Range(0, -2));
            Moved?.Invoke(Mathf.Abs(_currentDirection.normalized.z));
        }
    }
}
