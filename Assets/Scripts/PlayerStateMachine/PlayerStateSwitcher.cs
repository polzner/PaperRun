using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStateSwitcher : MonoBehaviour
{
    [SerializeField] private List<BaseDamagedState> _allStates;

    private BaseDamagedState _currentState;

    private void Start()
    {
        _currentState = _allStates[0];
    }

    public void SwitchState<T>() where T : BaseDamagedState
    {
        var state = _allStates.FirstOrDefault(state => state is T);
        _currentState.Stop();
        state.Begin();
        _currentState = state;
    }
}
