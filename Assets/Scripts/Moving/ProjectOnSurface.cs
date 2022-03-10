using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectOnSurface : MonoBehaviour
{
    private Vector3 _normal;

    public Vector3 Project(Vector3 direction)
    {
        return direction - Vector3.Dot(direction, _normal) * _normal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _normal = collision.contacts[0].normal;
    }
}
