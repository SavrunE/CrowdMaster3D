using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAttackTransition : PlayerTransition
{
    [SerializeField] private AttackState attackState;

    public override void Enable()
    {
        attackState.AbilityEnded += OnAbilityEnded;
    }
    
    public void OnDisable()
    {
        attackState.AbilityEnded -= OnAbilityEnded;
    }

    private void OnAbilityEnded()
    {
        NeedTransit = true;
    }

    void Update()
    {
        
    }
}
