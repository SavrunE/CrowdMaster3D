using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : PlayerState
{
    [SerializeField] private StaminaAccumulator staminaAccumulator;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speedRatio;

    private void OnEnable()
    {
        playerInput.DirectionChanged += OnDirectionChange;
        staminaAccumulator.StartAccumulate();
    }

    private void OnDisable()
    {
        playerInput.DirectionChanged -= OnDirectionChange;

        Animator.SetFloat("run", 0);
    }

    private void OnDirectionChange(Vector2 directionChanged)
    {
        Body.velocity = new Vector3(directionChanged.x, 0, directionChanged.y) * speedRatio;

        var bodyMagnitude = Body.velocity.magnitude;

        if (bodyMagnitude > maxSpeed)
            Body.velocity *= maxSpeed / bodyMagnitude;

        if (bodyMagnitude != 0)
            Body.MoveRotation(Quaternion.LookRotation(Body.velocity, Vector3.up));
    }
    private void Update()
    {
        Animator.SetFloat("run", Body.velocity.magnitude / maxSpeed);

    }
}
