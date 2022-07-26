using UnityEngine;
public static class Extention
{
    public static void SetIKPositionAndWeight(this Animator animator, AvatarIKGoal goal, Vector3 goalPosition, float value)
    {
        animator.SetIKPositionWeight(goal, value);
        animator.SetIKPosition(goal, goalPosition);
    }

    public static void SetIKRotationAndWeight(this Animator animator, AvatarIKGoal goal, Quaternion goalRotation, float value)
    {
        animator.SetIKRotationWeight(goal, value);
        animator.SetIKRotation(goal, goalRotation);
    }

    public static void SetIKTransformAndWeight(this Animator animator, AvatarIKGoal goal, Transform transform, float value = 1.0f)
    {
        animator.SetIKPositionWeight(goal, value);
        animator.SetIKPosition(goal, transform.position);
        animator.SetIKRotationWeight(goal, value);
        animator.SetIKRotation(goal, transform.rotation);
    }
}
