using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaAccumulator : MonoBehaviour
{
    [SerializeField] private float accumulationTime;
    [SerializeField] private Ability ability;
    [SerializeField] private Ability ultimateAbility;

    private float staminaValue;

    public void StartAccumulate()
    {
        staminaValue = 0;
    }

    private void Update()
    {
        staminaValue += Time.deltaTime;
    }

    public Ability GetAbility()
    {
        if (staminaValue > accumulationTime)
        {
            return ultimateAbility;
        }
        return ability;
    }
}
