using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
public class Vegeta : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite spriteDown;
    [SerializeField] private Sprite spriteUp;
    private bool isDown = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (isDown)
                spriteRenderer.sprite = spriteUp;
            else
                spriteRenderer.sprite = spriteDown;
            isDown = !isDown;
        }
    }

    internal void Reset()
    {
        isDown = false;
        spriteRenderer.sprite = spriteUp;
    }
}