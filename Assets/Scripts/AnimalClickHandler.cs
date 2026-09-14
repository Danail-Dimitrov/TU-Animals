using UnityEngine;

public class AnimalClickHandler : MonoBehaviour
{
    public Animator animator;
    private bool isRunning = false;

    void OnMouseDown()
    {
        isRunning = !isRunning;

        if (isRunning)
        {
            animator.SetFloat("Vert", 1f);
            animator.SetFloat("State", 1f);
        }
        else
        {
            animator.SetFloat("Vert", 0f);
        }
    }
}