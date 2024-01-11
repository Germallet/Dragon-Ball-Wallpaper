using UnityEngine;

public class WallpaperGoku : Wallpaper
{
    [SerializeField] private Goku goku;

    public override void Deactivate() => goku.Reset();
}