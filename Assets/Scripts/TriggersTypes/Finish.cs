using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour, ITrigger
{
    public void Accept(CharacterVisitor visitor)
    {
        visitor.Visit(this);
    }
}
