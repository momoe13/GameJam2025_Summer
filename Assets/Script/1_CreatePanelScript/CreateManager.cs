using UnityEngine;

public class CreateManager : MonoBehaviour
{
    int[] CreateNum = new int [2];

    // GameObject[] CreatePrefabs;    //生成オブジェクト


    GenerationManager manager;
    

    private void Start()
    {
        manager = GameObject.Find("GenerationManager").GetComponent<GenerationManager>();

    }
    public void SetItem(int itemNum)
    {
        //アイテムを設置する
        if (CreateNum[0] == 0) {
            //左のボックスにアイテムをセット
            CreateNum[0] = itemNum; 
        }
        else { CreateNum[1] = itemNum;

            //キャラクター生成
            int Item = CreateNum[0] * 10 + CreateNum[1];
            //生成できるキャラか探す
            manager.SetNum(Item);
            //選択初期化
            for (int i = 0; i < CreateNum.Length; i++) { CreateNum[i] = 0; }
        }
    }

}
