using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : CharacterInput
{
    [SerializeField] private Vector3 _direction = new Vector3(0, 0, -1);

    private void Update()
    {       
        if (Input.GetMouseButton(0))
        {
            Mover.Move(_direction);
        }
        else
        {
            Mover.Move(Vector3.zero);
        }
    }
}
