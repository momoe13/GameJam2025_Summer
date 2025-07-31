using System.Linq;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    int[] CreateNum = new int[2];

    // GameObject[] CreatePrefabs;    //生成オブジェクト
    int[] ItemNum = { 12, 13, 14, 23, 24, 34 };

    GenerationManager manager;


    private void Start()
    {
        manager = GameObject.Find("GenerationManager").GetComponent<GenerationManager>();

    }
    public void SetItem(int itemNum)
    {
        //アイテムを設置する
        if (CreateNum[0] == 0)
        {
            //左のボックスにアイテムをセット
            CreateNum[0] = itemNum;
        }
        else
        {
            CreateNum[1] = itemNum;

            if (CreateNum[0] > CreateNum[1])
            {
                //値を入れ替える
                (CreateNum[1], CreateNum[0]) = (CreateNum[0], CreateNum[1]);
            }
            //整数に変換
            int Item = CreateNum[0] * 10 + CreateNum[1];
            if (ItemNum.Any(s => s == Item))
            {
                manager.SetNum(Item);
            }
            else
            {
                var itemBox = GameObject.Find("Bag").GetComponent<ItemBox>();
                itemBox.AddItem(CreateNum[0]);
                itemBox.AddItem(CreateNum[1]);
            }

            //選択初期化
            for (int i = 0; i < CreateNum.Length; i++) { CreateNum[i] = 0; }

            /*
            木１
            羽   4
            木の実 3
            魔石2
             */
        }
    }

}
