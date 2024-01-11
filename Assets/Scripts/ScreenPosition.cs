using UnityEngine;

public class ScreenPosition : MonoBehaviour
{
    [SerializeField] private Vector3 screenRelativePosition;

    private void Update()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(screenRelativePosition);
        transform.position = new Vector3(screenPosition.x, screenPosition.y, 0f);
    }
}