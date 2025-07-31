using Unity.VisualScripting;
using UnityEngine;

public class IconSet : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.GetChild(0).gameObject.SetActive(true);  
    }
}
