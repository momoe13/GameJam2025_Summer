using UnityEngine;

public class CreateManager : MonoBehaviour
{
    [SerializeField]
    int[] CreateNum = new int [2];

    // GameObject[] CreatePrefabs;    //�����I�u�W�F�N�g
    int[] ItemNum =  {12,13,14,23,24,34};

    GenerationManager manager;
    

    private void Start()
    {
        manager = GameObject.Find("GenerationManager").GetComponent<GenerationManager>();

    }
    public void SetItem(int itemNum)
    {
        //�A�C�e����ݒu����
        if (CreateNum[0] == 0) {
            //���̃{�b�N�X�ɃA�C�e�����Z�b�g
            CreateNum[0] = itemNum; 
        }
        else { CreateNum[1] = itemNum;

            if ( CreateNum[0]> CreateNum[1])
            {
                //�l�����ւ���
                (CreateNum[1], CreateNum[0]) = (CreateNum[0], CreateNum[1]);
            }
            //�����ɕϊ�
            int Item = CreateNum[0] * 10 + CreateNum[1];
            //TODO:�����ł��邩�T��
            for(int i = 0; i < ItemNum.Length;i++)
            {
                if(ItemNum[i] == Item) {
                    //�ԍ��𑗂�
                    manager.SetNum(Item);
                    break;
                }
            }

            Debug.Log(Item);
            //�I��������
            for (int i = 0; i < CreateNum.Length; i++) { CreateNum[i] = 0; }

            /*
            �؁@�P
            �H   4
            �؂̎� �@3
            ���΁@2
             */
        }
    }

}
