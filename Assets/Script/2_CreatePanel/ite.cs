using UnityEngine;

public class ite : MonoBehaviour
{
    bool Mouse;
    Vector2 MousePos,ThisPos;
    private void Start()
    {
        GameObject Mouse=GetComponent<GameObject>();
        
    }
    private void �@Update()
    {
        //�}�E�X�̈ʒu���擾
        MousePos = Input.mousePosition;
        //�����̈ʒu�𔽉f
        transform.position = MousePos;   
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Mouse){ return; }

        //���������̂��A�C�e��������
        if (collision.CompareTag("ItemBox"))
        {
            //��������

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
