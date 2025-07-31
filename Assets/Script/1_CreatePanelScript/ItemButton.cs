using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            thisButton.interactable = _count > 0;
            countText.text = $"Å~{_count}";
        }
    }

    Button thisButton;
    TMP_Text countText;

    private void Start()
    {
        manager = GameObject.Find("CreateManager").GetComponent<CreateManager>();
        thisButton = GetComponent<Button>();
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
