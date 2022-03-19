using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private List<Character> _characters;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var character in _characters)
            {
                character.Input.enabled = true;
                character.Input.Begin();
            }

            gameObject.SetActive(false);
        }
    }
}
