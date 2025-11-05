using UnityEngine;

public static class CharacterAnimationsHash
{
    public static readonly int Idle = Animator.StringToHash("Idle");
    public static readonly int Run = Animator.StringToHash("Run");
    public static readonly int MoveSpeedMultiplierParameter = Animator.StringToHash("MoveSpeedMultiplier");
}
