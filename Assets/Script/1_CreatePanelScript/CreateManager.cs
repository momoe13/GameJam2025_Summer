using UnityEngine;

public class CreateManager : MonoBehaviour
{
    int[] CreateNum = new int [2];

    // GameObject[] CreatePrefabs;    //�����I�u�W�F�N�g


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

            //�L�����N�^�[����
            int Item = CreateNum[0] * 10 + CreateNum[1];
            //�����ł���L�������T��
            manager.SetNum(Item);
            //�I��������
            for (int i = 0; i < CreateNum.Length; i++) { CreateNum[i] = 0; }
        }
    }

}
