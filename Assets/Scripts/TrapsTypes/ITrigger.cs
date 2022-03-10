using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrigger
{
    void Accept(CharacterVisitor visitor);
}
