using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisitor : MonoBehaviour
{
    [SerializeField] private CharacterStateSwitcher _playerStateSwitcher;

    public void Visit(Arrows arrows)
    {
        _playerStateSwitcher.SwitchState<ArrowsDamagedState>();
    }

    public void Visit(Fire fire)
    {
        _playerStateSwitcher.SwitchState<FireDamagedState>();
    }

    public void Visit(Hammer hammer)
    {
        _playerStateSwitcher.SwitchState<HammerDamagedState>();
    }

    public void Visit(Blade blade)
    {
        _playerStateSwitcher.SwitchState<BladeDamagedState>();
    }

    public void Visit(Finish finish)
    {
        _playerStateSwitcher.SwitchState<WonState>();
    }
}
