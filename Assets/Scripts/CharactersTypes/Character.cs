using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private CharacterStateSwitcher _stateSwither;
    [SerializeField] private CharacterInput _input;

    public CharacterStateSwitcher StateSwitcher => _stateSwither;
    public CharacterInput Input => _input;
}
