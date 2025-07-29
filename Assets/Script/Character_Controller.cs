using Unity.VisualScripting;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField] int character_id;//識別子
    int target_direction;             //進行方向

    [SerializeField] float      speed;//移動速度
    [SerializeField] float          hp;//体力

    [SerializeField] float attack_Timing;//攻撃タイミング
    float                   attack_Time;//攻撃までのカウントダウン用タイム
    protected string            target;//攻撃するオブジェクト


    [SerializeField]
    protected bool MoveFlg = false;

    private void Start()
    {
        //プレイヤーキャラの場合右に動く
        if (character_id == 0) { target_direction = 1; }
        //敵は左に向かって動く
        else { target_direction = -1; }
    }

    private void Update()
    {
        Move();
        attack_Time = Time.time;
        if (target != null) { Attack(); }
 
    }

    protected virtual void Move()
    {
        if(MoveFlg) return;
        Vector2 pos = transform.position;
        transform.position = new Vector2(pos.x+(speed * target_direction) , pos.y);

    }

    protected virtual void Attack()
    {
        //Debug.Log("上位呼び出し");
       if(attack_Time < attack_Timing)return;

    }
    public void Damage(int dm)
    {
        Debug.Log("攻撃された！"+this.gameObject.name);
        hp -= dm;
        Die();
    }
    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("あああ");
        MoveFlg = true;
        target = collision.gameObject.name;
        Debug.Log(target);
        Attack();
    }
}
