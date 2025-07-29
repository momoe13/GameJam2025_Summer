using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    int Type;
    bool GeneratFlg= false;
    [SerializeField]//�����A�C�e��
    GameObject[] CreatePrefabs;

    private void Update()
    {
        if (GeneratFlg) PLGeneration();
    }

    private void PLGeneration()
    {
        Instantiate(CreatePrefabs[Type], this.transform.position, Quaternion.identity);
        GeneratFlg = false;
    }
    public void SetNum(int num)
    {
        Type = num;
        GeneratFlg = true;
    }
}
