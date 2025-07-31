using TMPro;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    [SerializeField] int ItemNum;
    public int ItemID => ItemNum;
    CreateManager manager;

    [SerializeField]
    int _count = 1;
    protected int Count
    {
        get => _count;
        set
        {
            _count = value;
            countText.text = $"Å~{_count}";
        }
    }

    TMP_Text countText;

    private void Start()
    {
        manager = GameObject.Find("CreateManager").GetComponent<CreateManager>();
        countText = GetComponentInChildren<TMP_Text>();
        Count = Count;
    }
    public void AddItem()
    {
        Count++;
    }
    public void GetButton()
    {
        if (Count <= 0)
        {
            return;
        }
        Count--;
        manager.SetItem(ItemNum);
    }
}
