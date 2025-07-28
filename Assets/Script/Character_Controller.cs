using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField] int character_id;//識別子
    int target_direction;             //進行方向

    [SerializeField] float      speed;//移動速度
    [SerializeField] float          hp;//体力

    [SerializeField] float attack_Timing;//攻撃タイミング
    float                   attack_Time;//攻撃までのカウントダウン用タイム

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
    }

    protected virtual void Move()
    {
        Vector2 pos = transform.position;
        transform.position = new Vector2(pos.x+(speed * target_direction) , pos.y);

    }

    protected virtual void Attack()
    {
        if(attack_Time < attack_Timing)return;

    }
    protected virtual void Damage(int dm)
    {
        hp -= dm;
    }
}
