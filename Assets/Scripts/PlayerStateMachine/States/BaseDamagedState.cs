using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDamagedState : MonoBehaviour
{
    [SerializeField] protected PlayerStateSwitcher StateSwitcher;
    [SerializeField] protected float Delay;

    public abstract void Begin();

    public abstract void Stop();
}
