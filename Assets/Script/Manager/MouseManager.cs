using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    DropItem drop;
    [SerializeField]    
    CircleCollider2D Coll;

   
    void Start()
    {
        Coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Coll.enabled = true;


            ////���C���g���ă}�E�X�̈ʒu������
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ////Ray�̒���
            //float maxDistance = 1;

            //RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);

            ////�Ȃɂ��ƏՓ˂������������̃I�u�W�F�N�g�̖��O�����O�ɏo��
            //if (hit.collider.CompareTag("ItemBox"))
            //{

            //    Debug.Log(hit.collider.gameObject.name);
            //}
            //if (hit.collider.CompareTag("DropItem"))
            //{

            //    Debug.Log(hit.collider.gameObject.name);
            //}

            ////////TODO: 2����
            //   Debug.DrawRay(ray.origin, ray.direction * 1, Color.red, 2.0f); // �����R�O�A�ԐF�łT�b�ԉ���

            //}

            //if(Input.GetMouseButtonDown(0))
            //{

            //}

           
        }
        if (Input.GetMouseButtonUp(0))
        {
            Coll.enabled = false;
        }

    }
}
