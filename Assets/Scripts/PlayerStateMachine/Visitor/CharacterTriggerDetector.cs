using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTriggerDetector : MonoBehaviour
{
    [SerializeField] private CharacterVisitor _visitor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ITrigger trap))
        {
            trap.Accept(_visitor);
        }
    }
}
