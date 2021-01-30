using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ability : ScriptableObject
{
    protected Rigidbody Body;

    public abstract event UnityAction AbilityEnded;
}
