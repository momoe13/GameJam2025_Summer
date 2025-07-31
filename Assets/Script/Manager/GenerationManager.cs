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

    float BossTime = 30.0f;

    //�G�L�����̐�������ۑ�����
    [SerializeField]
    List<GameObject> EnemyBox;
    int eneType = 0;

    //�{�X�𐶐�������
    bool isBossGenerated = false;

    // TODO : �~�T�C�����Ƃ肠�������������߂̒ǉ��I�I��ŕς��܂��傤
    public IReadOnlyList<GameObject> ActiveEnemyList => EnemyBox;
    

    public Boss bossTest;
    public void TestGenerateBoss()
    {
        //�{�X����
        var obj = Instantiate(CreatePrefabs[5], GetEnemySpawnPos(), Quaternion.identity);
        bossTest = obj.GetComponent<Boss>(); 
    }

    private void Update()
    {
        //�v���C���[�̃L�����N�^�[�𐶐�
        if (GeneratFlg) PLGeneration();

        //�{�X�̐���
        if(!isBossGenerated)
        {
            gameTime = Time.deltaTime;
            if (BossTime < gameTime)
            {
                //�{�X����
                Instantiate(CreatePrefabs[5], GetEnemySpawnPos(), Quaternion.identity);
                isBossGenerated = true;
                return;
            }
        }

        //null�ɂȂ��Ă���ꏊ��|��
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
        GameObject ene= Instantiate(CreatePrefabs[eneType], GetEnemySpawnPos(), Quaternion.identity);
       
        EnemyBox.Add(ene);
        eneType++;
        if (eneType > 1) eneType = 0;
    }

    private Vector2 GetEnemySpawnPos()
    {
        return new Vector2(this.transform.position.x + 18.0f, this.transform.position.y);
    }


    public void SetNum(int num)
    {
        //23,24,34
        switch (num)
        {
            case 23:
                num = 9;
                break;
            case 24:
                num = 10;
                break;
            case 34:
                num = 11;
                break;
        }
        Type = num;
        GeneratFlg = true;
    }
}
