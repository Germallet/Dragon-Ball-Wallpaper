using UnityEngine;

public class WallpaperVegeta : Wallpaper
{
    [SerializeField] private Vegeta vegeta;
    [SerializeField] private VegetaCounter vegetaCounter;

    public override void Deactivate()
    {
        vegeta.Reset();
        vegetaCounter.Reset();
    }
}