using UnityEngine;
using UnityEngine.EventSystems;

public class VegetaCounter : MonoBehaviour
{
    [SerializeField] private GameObject digit0;
    [SerializeField] private SpriteRenderer digitA, digitB1, digitB2, digitC1, digitC2, digitC3;
    [SerializeField] private Sprite[] nums;

    private int clicks = 0;

    private int GetPlace(int value, int place) => ((value % (place * 10)) - (value % place)) / place;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            clicks++;
            int count = Mathf.FloorToInt(clicks / 2);
            if (count > 0 && count < 10)
            {
                digit0.SetActive(false);
                digitA.gameObject.SetActive(true);
                digitA.sprite = nums[count];
            }
            else if(count >= 10 && count < 100)
            {
                digitA.gameObject.SetActive(false);
                digitB1.gameObject.SetActive(true);
                digitB2.gameObject.SetActive(true);
                digitB1.sprite = nums[(count - count % 10) / 10];
                digitB2.sprite = nums[count % 10];
            }
            else if (count >= 100)
            {
                if (count > 999)
                    count = 999;
                digitB1.gameObject.SetActive(false);
                digitB2.gameObject.SetActive(false);
                digitC1.gameObject.SetActive(true);
                digitC2.gameObject.SetActive(true);
                digitC3.gameObject.SetActive(true);
                digitC1.sprite = nums[GetPlace(count, 100)];
                digitC2.sprite = nums[GetPlace(count, 10)];
                digitC3.sprite = nums[GetPlace(count, 1)];
            }
        }
    }

    public void Reset()
    {
        clicks = 0;
        digit0.SetActive(true);
        digitA.gameObject.SetActive(false);
        digitB1.gameObject.SetActive(false);
        digitB2.gameObject.SetActive(false);
        digitC1.gameObject.SetActive(false);
        digitC2.gameObject.SetActive(false);
        digitC3.gameObject.SetActive(false);
    }
}