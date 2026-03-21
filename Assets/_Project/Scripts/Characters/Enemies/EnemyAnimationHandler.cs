using UnityEngine;

public class EnemiesAnimationHandler : AnimationManager
{
    public void MovementAnimation(Vector2 dir)
    {
        animator.SetFloat(verticalSpeedName, dir.y);
        animator.SetFloat(horizontalSpeedName, dir.x);

        animator.SetBool("isMoving", dir != Vector2.zero);
    }
}