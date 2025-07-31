using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    int Type;
    bool GeneratFlg= false;
    [SerializeField]//�����A�C�e��
    GameObject[] CreatePrefabs;

    int maxEne=3;
    float gameTime= 0;

    //�G�L�����̐�������ۑ�����
    [SerializeField]
    List<GameObject> EnemyBox;
    int eneType = 0;


    private void Update()
    {
        if (GeneratFlg) PLGeneration();
        //�{�X���o��܂ōX�V����
       // gameTime = Time.time;
        
        for (int i = 0; i < EnemyBox.Count; i++)
        {
            if(EnemyBox[i] == null) EnemyBox.Remove(EnemyBox[i]);
        }

        //�G�����̈ȉ��Ȃ琶��
        if(EnemyBox.Count<maxEne)
        {

            EnemyGeneration();
        }
    }

    //�v���C���[�L��������
    private void PLGeneration()
    {
        Instantiate(CreatePrefabs[Type], this.transform.position, Quaternion.identity);
        GeneratFlg = false;

    }

    //�G����
    private void EnemyGeneration()
    {
        GameObject ene= Instantiate(CreatePrefabs[eneType], new Vector2(this.transform.position.x + 18.0f, this.transform.position.y), Quaternion.identity);
       
        EnemyBox.Add(ene);
        eneType++;
        if (eneType > 1) eneType = 0;
    }


    public void SetNum(int num)
    {
        Type = num;
        GeneratFlg = true;
    }
}
