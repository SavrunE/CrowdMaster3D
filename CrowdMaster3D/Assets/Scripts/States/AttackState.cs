using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{
    [SerializeField] private StaminaAccumulator staminaAccumulator;

    private Ability currentAbility;

    public event Action<IDamageable> CollisionDetected;
    public event Action AbilityEnded;

    private void OnEnable()
    {
        currentAbility = staminaAccumulator.GetAbility();
        currentAbility.AbilityEnded += OnAbilityEnded;

        currentAbility.UseAbility(this);
    }

    private void OnDisable()
    {

        currentAbility.AbilityEnded -= OnAbilityEnded;
    }

    private void OnAbilityEnded()
    {
        AbilityEnded?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            CollisionDetected?.Invoke(damageable);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            CollisionDetected?.Invoke(damageable);
        }
    }

    private void Update()
    {
        
    }
}
