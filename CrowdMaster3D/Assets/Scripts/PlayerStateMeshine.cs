using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animation))]
public class PlayerStateMeshine : MonoBehaviour
{
    [SerializeField] private PlayerState firstState;

    private PlayerState currentState;
    private Rigidbody body;
    private Animator animator;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        currentState = firstState;
        currentState.Enter(body, animator);
    }
    private void Update()
    {
        if (currentState == null)
            return;

        PlayerState nextState = currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(PlayerState nextState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = nextState;

        if (currentState != null)
            currentState.Enter(body, animator);
    }
}
