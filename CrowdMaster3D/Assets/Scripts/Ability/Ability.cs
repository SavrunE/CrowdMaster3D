using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ability : ScriptableObject
{
    protected Rigidbody Body;

    //public delegate void AbilityDelegate();
    //public AbilityDelegate AbilityEnded;

    public abstract event Action AbilityEnded;

    public void Init(Rigidbody body)
    {
        Body = body;
    }

    public abstract void UseAbility(AttackState attack);
}
