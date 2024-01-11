using UnityEngine;
using UnityEngine.EventSystems;

public class Gohan : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private WallpaperGohan wallpaper;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AutoDown"))
            animator.SetInteger("CurrentStep", 0);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AutoMiddle"))
            animator.SetInteger("CurrentStep", 1);

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            animator.SetTrigger("Step");
            int currentStep = animator.GetInteger("CurrentStep");
            if (currentStep == 8)
            {
                animator.SetInteger("CurrentStep", 0);
                transform.position = wallpaper.GetNextSwordPos();
            }
            else
                animator.SetInteger("CurrentStep", currentStep + 1);
        }
    }

    public void ResetSteps() => animator.SetInteger("CurrentStep", 0);

    public void Reset()
    {
        transform.position = wallpaper.GetNextSwordPos();
    }
}