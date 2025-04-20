using UnityEngine;

public class PlayerAnimationsHash
{
    public int Idle => Animator.StringToHash("Idle");
    public int Run => Animator.StringToHash("Run");
    public int MoveMultiplierParameter => Animator.StringToHash("MoveSpeedMultiplier");
}
