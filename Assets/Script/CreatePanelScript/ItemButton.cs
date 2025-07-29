using UnityEngine;

public class ItemButton : MonoBehaviour
{
    [SerializeField] int ItemNum;
    CreateManager manager;

    private void Start()
    {
        manager = GameObject.Find("CreateButton").GetComponent<CreateManager>();
    }
    public void GetButton()
    {
        manager.SetItem(ItemNum);
    }
}
