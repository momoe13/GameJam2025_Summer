using UnityEngine;

public class StageSelect : MonoBehaviour
{
    [SerializeField]
    GameObject[] StageObj;

    private void Start()
    {
        for (int i = 0; i < StageObj.Length; i++)
        {
            StageObj[i].SetActive(false);
        }
    }

}
