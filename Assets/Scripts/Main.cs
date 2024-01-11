using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private Wallpaper[] wallpapers;
    [SerializeField] private Wallpaper currentWallpaper;

    private void Start()
    {
        int i = Random.Range(0, wallpapers.Length);
        currentWallpaper = wallpapers[i];
        currentWallpaper.Activate();
        currentWallpaper.gameObject.SetActive(true);
    }

    public void SetWallpaper(Wallpaper newWallpaper)
    {
        currentWallpaper.gameObject.SetActive(false);
        currentWallpaper.Deactivate();

        currentWallpaper = newWallpaper;

        currentWallpaper.Activate();
        currentWallpaper.gameObject.SetActive(true);
    }
}