using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAbility : Ability
{
    [SerializeField] private float attackForce;
    [SerializeField] private float usefulTime;

    [Range(2f,5f)]
    [SerializeField] private float slowerSpeedOnWrongAttack = 2f;

    private AttackState attackState;
    private Coroutine coroutine;

    public override event Action AbilityEnded;

    public override void UseAbility(AttackState attack)
    {
        if (coroutine != null)
        {
            Reset();
        }

        attackState = attack;

        coroutine = attackState.StartCoroutine(Attack(attackState));
        attackState.CollisionDetected += OnPlayerAttack;
    }

    private void OnPlayerAttack(IDamageable damageable)
    {
        if (damageable.ApplyDamage(attackState.Body, attackForce) == false)
            return;
        attackState.Body.velocity /= slowerSpeedOnWrongAttack;
    }
    private IEnumerator Attack(AttackState attackState)
    {
        float time = usefulTime;

        while (time > 0)
        {
            attackState.Body.velocity = attackState.Body.velocity.normalized * attackForce;
            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Reset();
        AbilityEnded?.Invoke();
    }

    private void Reset()
    {
        attackState.Body.velocity = Vector3.zero;
        attackState.StopCoroutine(coroutine);
        coroutine = null;
        attackState.CollisionDetected -= OnPlayerAttack;
    }
}
