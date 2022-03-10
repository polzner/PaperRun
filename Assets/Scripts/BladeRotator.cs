using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        Quaternion rotationY = Quaternion.AngleAxis(_rotationSpeed, Vector3.up);
        transform.rotation *= rotationY;
    }
}
