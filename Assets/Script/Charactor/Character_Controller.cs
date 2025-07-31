using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Character_Controller : MonoBehaviour
{
    [Header("プレイヤーキャラには✔入れる")]
    [SerializeField] bool ally;//���ʎq
    int target_direction;             //�i�s����

    [Header("パラメーター")]
    [SerializeField] float      speed;//�ړ����x
    [SerializeField] float          hp;//�̗�

    [SerializeField] float coolTime;//クールタイム

    float                   attack_Time;//攻撃までのカウントダウン用タイム
    protected string            target;//攻撃するオブジェクト

    [SerializeField] int attackPower;

    [Header ("ダメージUI用Prefab")]
    [SerializeField] GameObject DamagePre;
    Canvas     DamageCanvas;

    [SerializeField]
    protected bool isStop = false;
    bool isCastel = false;

    public Character_Controller attackTarget;

    Vector2 pos, scale;//死亡モーション用。
    bool DieFlg = false;//死亡判定

    BoxCollider2D boxCollider;

    [Header("アニメーター")]
    [SerializeField] Animator anim;

    [Header("ドロップアイテム")]
    [SerializeField]
    GameObject DropItem;


    private void Start()
    {
        //時機なら右に向かって動く
        if (ally) { target_direction = 1; }

        else { target_direction = -1; }

        scale= transform.localScale;
        DamageCanvas = GameObject.Find("DamageCanvas").GetComponent<Canvas>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim.SetBool("AttackFlg", false);
    }

    private void Update()
    {
        if (DieFlg) { 
            Die();        }
        else
        {
            Move();
            attack_Time += Time.deltaTime;

        }
        if (Input.GetKeyDown(KeyCode.Escape)) { Damage(5); }
        ////Rayを配列にして当たったもの全て出す
        //RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector2(target_direction,0), 2.0f);//中心点、方向、長さ
        //Debug.DrawRay(transform.position, new Vector2(target_direction*2, 0), Color.red, 1.0f); // 長さ2、赤色で1秒間可視化
        //                                                                                        // Debug.Log(hit.collider.tag);

        //for (int i = 0; i < hit.Length; i++)
        //{
        //    if (hit[i].collider.CompareTag(TargetTag))
        //    {
        //        target = hit[i].collider.gameObject.name;
        //        Debug.Log(target);
        //        MoveFlg = true;

        //        if (target == null) { return; }
        //        Attack();
        //    }
        //}
        
    }

    protected virtual void Move()
    {
        if (isStop)
        {
            Attack();
            return;
        }

        Vector2 pos = transform.position;
        transform.position = new Vector2(pos.x+(speed * target_direction*Time.deltaTime) , pos.y);

    }

    protected virtual void Attack()
    {
        //Debug.Log(string.Format( "{0}/{1}", attack_Time,attack_Timing));
        if (attack_Time < coolTime){ return; }
        anim.SetBool("AttackFlg", true);
        attack_Time = 0.0f;
        if (isCastel) { return; }
        //Damege関数呼び出し
        attackTarget.Damage(attackPower);
    }

    public void Damage(int dm)
    {
        if (DieFlg) return ;
        hp -= dm;
        DamageTex(dm);
        if (hp <= 0) { DieFlg = true; }
        Debug.Log("ダメージ"+this.gameObject.name);
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
    private void OnTriggerStay2D(Collider2D collision)
    {

        //if (Vector3.Distance(transform.position, collision.transform.position) <= boxCollider.size.x / 2.0f)
        //{
        if ( collision.gameObject.name == ("kyassuru_0"))
        {
            StartCoroutine("AttackWait");

            isCastel = true;
            CastelManager castel = GameObject.Find(collision.gameObject.name).GetComponent<CastelManager>();
            castel.CastelDamage();
        }
        else if (collision.gameObject.name == ("Target"))
        {            //ターゲット名からターゲットとそのスクリプトを取得
            attackTarget = GameObject.Find(collision.gameObject.name).GetComponent<Character_Controller>();
            Debug.Log(collision.gameObject.name);
            StartCoroutine("MovingCancel");
        }
        //}

    }

    IEnumerator MovingCancel()
    {
        yield return new WaitForSeconds(0.1f);
        isStop = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.CompareTag(this.tag)) { return; }
        StartCoroutine("MovingStart");
        //controller = null;
    }

    IEnumerator MovingStart()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("AttackFlg", false);
        isStop = false;

    }
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(0.5f);
        isStop = true;
    }
}
