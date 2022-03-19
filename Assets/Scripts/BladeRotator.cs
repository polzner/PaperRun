using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeRotator : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationVector;
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        Quaternion rotation = Quaternion.AngleAxis(_rotationSpeed, _rotationVector);
        transform.rotation *= rotation;
    }
}
