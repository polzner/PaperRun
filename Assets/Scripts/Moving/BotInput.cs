using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotInput : CharacterInput
{
    [SerializeField] private Vector3 _direction = new Vector3(0, 0, -1);
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
            _currentDirection = _direction * UnityEngine.Random.Range(0, 2);
        }
    }
}
