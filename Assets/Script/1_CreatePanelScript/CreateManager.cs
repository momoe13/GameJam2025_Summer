using System.Linq;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    int[] CreateNum = new int[2];

    // GameObject[] CreatePrefabs;    //�����I�u�W�F�N�g
    int[] ItemNum = { 12, 13, 14, 23, 24, 34 };

    GenerationManager manager;


    private void Start()
    {
        manager = GameObject.Find("GenerationManager").GetComponent<GenerationManager>();

    }
    public void SetItem(int itemNum)
    {
        //�A�C�e����ݒu����
        if (CreateNum[0] == 0)
        {
            //���̃{�b�N�X�ɃA�C�e�����Z�b�g
            CreateNum[0] = itemNum;
        }
        else
        {
            CreateNum[1] = itemNum;

            if (CreateNum[0] > CreateNum[1])
            {
                //�l�����ւ���
                (CreateNum[1], CreateNum[0]) = (CreateNum[0], CreateNum[1]);
            }
            //�����ɕϊ�
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

            //�I��������
            for (int i = 0; i < CreateNum.Length; i++) { CreateNum[i] = 0; }

            /*
            �؂P
            �H   4
            �؂̎� 3
            ����2
             */
        }
    }

}
