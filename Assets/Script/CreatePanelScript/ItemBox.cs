using UnityEngine;

public class ItemBox : MonoBehaviour
{
    bool IsMouse;
    private void Update()
    {
        //マウスの当たり判定がTrue
        if(IsMouse)
        {
            //マウスの位置を追従する
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
