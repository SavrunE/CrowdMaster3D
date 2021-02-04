using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable
{
    public bool ApplyDamage(Rigidbody body, float force)
    {
        Debug.Log("Box"); 
        return true;
    }
}
