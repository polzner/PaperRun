using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour, ITrigger
{
    public void Accept(CharacterVisitor visitor)
    {
        visitor.Visit(this);
    }
}
