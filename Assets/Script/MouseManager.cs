using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using Color = UnityEngine.Color;

public class MouseManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {

            //���C���g���ă}�E�X�̈ʒu������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Ray�̒���
            float maxDistance = 1;

            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);

            //�Ȃɂ��ƏՓ˂������������̃I�u�W�F�N�g�̖��O�����O�ɏo��
            if (hit.collider.CompareTag("ItemBox"))
            {
                Debug.Log(hit.collider.gameObject.name);
            }

            





            //TODO:2����
            Debug.DrawRay(ray.origin, ray.direction * 1, Color.red, 5.0f); // �����R�O�A�ԐF�łT�b�ԉ���

        }

        if (Input.GetMouseButtonDown(0))
        {
        }
    }
}
