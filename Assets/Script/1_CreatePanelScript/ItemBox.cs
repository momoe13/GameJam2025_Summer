using System.Linq;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    ItemButton[] itemButtons;

    private void Start()
    {
        itemButtons = GetComponentsInChildren<ItemButton>();
    }
    public void AddItem(int itemID)
    {
        var targetButton = itemButtons.FirstOrDefault(s => s.ItemID == itemID);
        if (targetButton == null)
        {
            return;
        }
        targetButton.AddItem();
    }
}
