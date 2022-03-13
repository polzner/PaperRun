using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    [SerializeField] protected CharacterStateSwitcher StateSwitcher;

    public abstract void Begin();

    public abstract void Stop();
}
