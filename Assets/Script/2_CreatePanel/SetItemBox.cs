using UnityEngine;

public class SetItemBox : MonoBehaviour
{
    [SerializeField] GameObject Item;

  public void GeneralItem()
    {
        Instantiate(Item, transform.position, Quaternion.identity);

    }
}