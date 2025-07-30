using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character_Controller : MonoBehaviour
{
    [Header("キャラID。一旦0なら右に移動。0以外は左に移動になってます")]
    [SerializeField] int character_id;//���ʎq
    int target_direction;             //�i�s����

    [Header("パラメーター")]
    [SerializeField] float      speed;//�ړ����x
    [SerializeField] float          hp;//�̗�

    [SerializeField] float attack_Timing;//攻撃タイミング
    float                   attack_Time;//攻撃までのカウントダウン用タイム
    protected string            target;//攻撃するオブジェクト

    [Header ("ダメージUI用Prefab")]
    [SerializeField] GameObject DamagePre;
    [SerializeField] Canvas     DamageCanvas;

    [SerializeField]
    protected bool MoveFlg = false;

    Vector2 pos, scale;//死亡モーション用。
    bool DieFlg = false;//死亡判定

    [Header("ドロップアイテム")]
    [SerializeField]
    GameObject DropItem;


    private void Start()
    {
        //時機なら右に向かって動く
        if (character_id == 0) { target_direction = 1; }

        else { target_direction = -1; }

        scale= transform.localScale;

     }

    private void Update()
    {
        if (DieFlg) { 
            Die();        }
        else
        {
            Move();
            attack_Time = Time.time;
            if (target != null) { 
                Attack(); 
                attack_Time =0;
            }
        }

 
    }

    protected virtual void Move()
    {
        if(MoveFlg) return;
        Vector2 pos = transform.position;
        transform.position = new Vector2(pos.x+(speed * target_direction) , pos.y);

    }

    protected virtual void Attack()
    {
       if(attack_Time < attack_Timing)return;

    }
    public void Damage(int dm)
    {
        hp -= dm;
        if (hp >= 0) { return; }
        DieFlg = true;  
        DamageTex(dm);
    }
    private void DamageTex(int dm)
    {
        Vector2 pos = new Vector2(Random.Range(transform.position.x - 1, transform.position.x + 1),
           Random.Range(transform.position.y - 1, transform.position.y + 1));

        //TODO:03　生成されない
        //テキスト生成
        Text damageIns = Instantiate(DamagePre, pos, Quaternion.identity, DamageCanvas.transform).GetComponent<Text>();
        //テキストの表示をダメージにする
        damageIns.text = dm.ToString();
    }


    protected virtual void Die()
    {
        if (scale.y > 0)
        {
            pos = transform.position;
            pos.y -= Time.deltaTime;
            scale.y -= Time.deltaTime;
            transform.position = pos;
            transform.localScale = scale;

        }
        else
        {
            if(DropItem != null)
            {
                //ドロップアイテム生成
                Instantiate(DropItem, pos, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveFlg = true;
        target = collision.gameObject.name;
        Attack();
    }
}
