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


            ////レイを使ってマウスの位置を見る
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ////Rayの長さ
            //float maxDistance = 1;

            //RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);

            ////なにかと衝突した時だけそのオブジェクトの名前をログに出す
            //if (hit.collider.CompareTag("ItemBox"))
            //{

            //    Debug.Log(hit.collider.gameObject.name);
            //}
            //if (hit.collider.CompareTag("DropItem"))
            //{

            //    Debug.Log(hit.collider.gameObject.name);
            //}

            ////////TODO: 2消す
            //   Debug.DrawRay(ray.origin, ray.direction * 1, Color.red, 2.0f); // 長さ３０、赤色で５秒間可視化

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
