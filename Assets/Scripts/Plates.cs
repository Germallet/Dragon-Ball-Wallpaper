using System;
using UnityEngine;

public class Plates : MonoBehaviour
{
    [SerializeField] private GameObject[] plates;
    public int Count { get; private set; } = 0;

    public void Add()
    {
        if (Count == 9)
        {
            foreach (GameObject plate in plates)
                plate.SetActive(false);
            Count = 0;
        }
        else
        {
            plates[Count].SetActive(true);
            Count++;
        }
    }

    internal void Reset()
    {
        foreach (GameObject plate in plates)
            plate.SetActive(false);
        Count = 0;
    }
}