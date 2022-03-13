using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterStateSwitcher : MonoBehaviour
{
    [SerializeField] private List<BaseState> _allStates;

    private BaseState _currentState;

    private void Start()
    {
        _currentState = _allStates[0];
        _currentState.Begin();
    }

    public void SwitchState<T>() where T : BaseState
    {
        BaseState state = _allStates.FirstOrDefault(state => state is T);

        if (state != _currentState)
        {
            _currentState.Stop();
            state.Begin();
            _currentState = state;
        }
        else
        {
            _currentState.Begin();
        }        
    }
}
