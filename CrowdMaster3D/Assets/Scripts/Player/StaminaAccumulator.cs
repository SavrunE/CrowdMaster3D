using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaAccumulator : MonoBehaviour
{
    [SerializeField] private float accumulationTime;

    private float staminaValue;

    public void StartAccumulate()
    {
        staminaValue = 0;
    }

    private void Update()
    {
        staminaValue += Time.deltaTime;
    }

    public void GetAbility()
    {
        if (staminaValue > accumulationTime)
        {
            Debug.Log("Ultimate");
        }
        Debug.Log("Attack");
    }
}
