using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : CharacterInput
{
    public override event Action<float> Moved;

    private void Update()
    {       
        if (Input.GetMouseButton(0))
        {
            Vector3 playerInput = new Vector3(0,0,-1);
            Mover.Move(playerInput);
        }

        if (Input.GetMouseButtonDown(0))
            Moved?.Invoke(1);

        if (Input.GetMouseButtonUp(0))
            Moved?.Invoke(0);
    }
}
