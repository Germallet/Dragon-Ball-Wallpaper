using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
public class WallpaperGohan : Wallpaper
{
    [SerializeField] private Gohan gohan;
    [SerializeField] private List<GameObject> swordList = new List<GameObject>();
    [SerializeField] private Transform swords;
    [SerializeField] private GameObject swordPrefab;
    private const float margin = 50f;

    public override void Activate()
    {
        base.Activate();
        Reset();
    }

    private void Reset()
    {
        for (int i = swordList.Count - 1; i >= 0; i--)
            Destroy(swordList[i]);
        swordList.Clear();

        int totalSwords = 20; //Mathf.FloorToInt(Random.Range(20, 24));
        for (int i = 0; i <= totalSwords; i++)
            AddSword(RandomPosition());
        gohan.Reset();
    }

    private Vector2 RandomPosition() => new Vector2(Random.Range(margin, Screen.width - margin), Random.Range(margin, Screen.height - margin));

    private void AddSword(Vector2 position)
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(position);
        GameObject newSword = Instantiate(swordPrefab, new Vector3(screenPosition.x, screenPosition.y, 1f), Quaternion.identity, swords);
        swordList.Add(newSword);
    }

    public Vector3 GetNextSwordPos()
    {
        if (swordList.Count == 0)
            Reset();

        int swordIndex = Mathf.FloorToInt(Random.Range(0, swordList.Count));
        GameObject sword = swordList[swordIndex];
        Vector3 pos = new Vector3(sword.transform.position.x, sword.transform.position.y, 0.1f);
        swordList.Remove(sword);
        Destroy(sword);
        return pos;
    }

    public override void Deactivate()
    {
    }
}