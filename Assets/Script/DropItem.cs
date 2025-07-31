using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DropItem : MonoBehaviour
{
    [SerializeField]
    bool MoveFlg = false;

    [SerializeField]
    Vector2 TargetPos;
    [SerializeField]
    float speed;

    [SerializeField]
    int ItemNum;

    private void Update()
    {
        if (MoveFlg)
        {
            ItemMove();
            if (transform.position.y <= TargetPos.y)
            {
                var itemBox = GameObject.Find("Bag").GetComponent<ItemBox>();
                itemBox.AddItem(ItemNum);
                Destroy(gameObject);
            }
        }
    }
    private void ItemMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MouseManager")
        {
            MoveFlg = true;
        }
    }
}
