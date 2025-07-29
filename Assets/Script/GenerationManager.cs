using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    int Type;
    bool GeneratFlg= false;
    [SerializeField]//生成アイテム
    GameObject[] CreatePrefabs;
    float gameTime= 0;

    private void Update()
    {
        if (GeneratFlg) PLGeneration();
        //ボスが出るまで更新する
        gameTime = Time.time;
        
        //敵がｎ体以下なら生成
        EnemyGeneration();
    }

    private void PLGeneration()
    {
        Instantiate(CreatePrefabs[Type], this.transform.position, Quaternion.identity);
        GeneratFlg = false;
    }
    private void EnemyGeneration()
    {
        //TODO:01 消す
        if (Input.GetKeyDown(KeyCode.K)) {
            Instantiate(CreatePrefabs[0], new Vector2(this.transform.position.x+18.0f, this.transform.position.y), Quaternion.identity);
        }
    }


        public void SetNum(int num)
    {
        Type = num;
        GeneratFlg = true;
    }
}
