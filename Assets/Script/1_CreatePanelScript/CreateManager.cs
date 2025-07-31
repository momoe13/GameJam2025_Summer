using UnityEngine;

public class CreateManager : MonoBehaviour
{
    [SerializeField]
    int[] CreateNum = new int [2];

    // GameObject[] CreatePrefabs;    //生成オブジェクト
    int[] ItemNum =  {12,13,14,23,24,34};

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

            if ( CreateNum[0]> CreateNum[1])
            {
                //値を入れ替える
                (CreateNum[1], CreateNum[0]) = (CreateNum[0], CreateNum[1]);
            }
            //整数に変換
            int Item = CreateNum[0] * 10 + CreateNum[1];
            //TODO:生成できるか探す
            for(int i = 0; i < ItemNum.Length;i++)
            {
                if(ItemNum[i] == Item) {
                    //番号を送る
                    manager.SetNum(Item);
                    break;
                }
            }

            Debug.Log(Item);
            //選択初期化
            for (int i = 0; i < CreateNum.Length; i++) { CreateNum[i] = 0; }

            /*
            木　１
            羽   4
            木の実 　3
            魔石　2
             */
        }
    }

}
