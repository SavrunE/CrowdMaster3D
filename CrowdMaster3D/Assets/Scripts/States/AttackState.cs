using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{
    [SerializeField] private StaminaAccumulator staminaAccumulator;

    private Ability currentAbility;

    public event Action CollisionDetected;
    public event Action AbilityEnded;

    private void OnEnable()
    {
        currentAbility = staminaAccumulator.GetAbility();
    }
}
