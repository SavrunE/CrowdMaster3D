using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    [SerializeReference] private PlayerTransition[] transitins;

    protected Rigidbody Body { get; private set; }
    protected Animator Animator { get; private set; }

    public void Enter(Rigidbody body, Animator animator)
    {
        if (enabled == false)
        {
            Body = body;
            Animator = animator;

            enabled = true;

            foreach (var transition in transitins)
            {
                transition.enabled = true;
            }
        }
    }
    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in transitins)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }
    public PlayerState GetNextState()
    {
        foreach (var transition in transitins)
        {
            return transition.TargetState;
        }
        return null;
    }
}
