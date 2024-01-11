using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class Goku : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Plates plates;
    [SerializeField] private GameObject platesPrefab;
    [SerializeField] private Vector3 platesPosition;
    [SerializeField] private Vector3 platesOffset;
    private bool openMouth = false;
    [SerializeField] private Transform platesContainer;

    private int platesCount = 0;
    private int clicksToEat = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (openMouth)
                animator.SetTrigger("Close");
            else
                animator.SetTrigger("Open");
            Step();
        }
    }

    public void Step()
    {
        openMouth = !openMouth;

        clicksToEat++;
        if (clicksToEat == 6)
        {
            plates.Add();
            clicksToEat = 0;

            if (plates.Count == 0)
                AddPlates();
        }
    }

    private void AddPlates()
    {
        if (platesCount < 100)
        {
            platesCount++;
            Instantiate(platesPrefab, transform.parent.transform.position + platesPosition + platesCount * platesOffset, Quaternion.identity, platesContainer);
        }
    }

    public void Reset()
    {
        foreach (Transform plates in platesContainer)
            Destroy(plates.gameObject);
        platesCount = 0;
        clicksToEat = 0;
        plates.Reset();
    }

    public void ResetClicks()
    {
        clicksToEat = 0;
        openMouth = false;
    }
}