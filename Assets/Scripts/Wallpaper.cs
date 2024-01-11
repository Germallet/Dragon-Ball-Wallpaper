using UnityEngine;

public abstract class Wallpaper : MonoBehaviour
{
    [SerializeField] private Color backgroundColor;

    public virtual void Activate()
    {
        Camera.main.backgroundColor = backgroundColor;
    }

    public abstract void Deactivate();
}