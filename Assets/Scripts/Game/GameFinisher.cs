using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinisher : MonoBehaviour
{
    [SerializeField] private List<Character> _characters;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Character character))
        {
            character.StateSwitcher.SwitchState<WonState>();

            foreach (var loseCharacter in _characters)
            {
                loseCharacter.Input.enabled = false;

                if (character != loseCharacter)
                    loseCharacter.StateSwitcher.SwitchState<DefeatState>();
            }
        }
    }
}
