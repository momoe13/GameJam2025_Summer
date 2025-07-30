using UnityEngine;

public class ite : MonoBehaviour
{
    bool Mouse;
    Vector2 MousePos,ThisPos;
    private void Start()
    {
        GameObject Mouse=GetComponent<GameObject>();
        
    }
    private void 　Update()
    {
        //マウスの位置を取得
        MousePos = Input.mousePosition;
        //自分の位置を反映
        transform.position = MousePos;   
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Mouse){ return; }

        //当たったのがアイテムだった
        if (collision.CompareTag("ItemBox"))
        {
            //合成する

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
