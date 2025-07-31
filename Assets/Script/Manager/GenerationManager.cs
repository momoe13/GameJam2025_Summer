using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    int Type;
    bool GeneratFlg= false;
    [SerializeField]//生成アイテム
    GameObject[] CreatePrefabs;

    int maxEne=3;
    float gameTime= 0;

    float BossTime = 30.0f;

    //敵キャラの生成数を保存する
    [SerializeField]
    List<GameObject> EnemyBox;
    int eneType = 0;

    // TODO : ミサイルをとりあえず動かすための追加！！後で変えましょう
    public IReadOnlyList<GameObject> ActiveEnemyList => EnemyBox;
    
    private void Update()
    {
        if (GeneratFlg) PLGeneration();
        //ボスが出るまで更新する
        gameTime = Time.deltaTime;
        if (BossTime < gameTime)
        {
            //ボス生成
            Instantiate(CreatePrefabs[5], this.transform.position, Quaternion.identity);
        }
        
        for (int i = 0; i < EnemyBox.Count; i++)
        {
            if(EnemyBox[i] == null) EnemyBox.Remove(EnemyBox[i]);
        }

        //敵がｎ体以下なら生成
        if(EnemyBox.Count<maxEne)
        {

            EnemyGeneration();
        }
    }

    //プレイヤーキャラ生成
    private void PLGeneration()
    {
        Instantiate(CreatePrefabs[Type], this.transform.position, Quaternion.identity);
        GeneratFlg = false;

    }

    //敵生成
    private void EnemyGeneration()
    {
        GameObject ene= Instantiate(CreatePrefabs[eneType], new Vector2(this.transform.position.x + 18.0f, this.transform.position.y), Quaternion.identity);
       
        EnemyBox.Add(ene);
        eneType++;
        if (eneType > 1) eneType = 0;
    }


    public void SetNum(int num)
    {
        //23,24,34
        switch (num)
        {
            case 23:
                num = 10;
                break;
            case 24:
                num = 11;
                break;
            case 34:
                break;
        }
        Type = num;
        GeneratFlg = true;
    }
}
