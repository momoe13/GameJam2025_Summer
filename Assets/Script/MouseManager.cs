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

            //レイを使ってマウスの位置を見る
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Rayの長さ
            float maxDistance = 1;

            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);

            //なにかと衝突した時だけそのオブジェクトの名前をログに出す
            if (hit.collider.CompareTag("ItemBox"))
            {
                Debug.Log(hit.collider.gameObject.name);
            }

            





            //TODO:2消す
            Debug.DrawRay(ray.origin, ray.direction * 1, Color.red, 5.0f); // 長さ３０、赤色で５秒間可視化

        }

        if (Input.GetMouseButtonDown(0))
        {
        }
    }
}
