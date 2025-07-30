using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character_Controller : MonoBehaviour
{
    [SerializeField] int character_id;//���ʎq
    int target_direction;             //�i�s����

    [SerializeField] float      speed;//�ړ����x
    [SerializeField] float          hp;//�̗�

    [SerializeField] float attack_Timing;//�U���^�C�~���O
    float                   attack_Time;//�U���܂ł̃J�E���g�_�E���p�^�C��
    protected string            target;//�U������I�u�W�F�N�g

    [SerializeField] GameObject DamagePre;
    [SerializeField] Canvas     DamageCanvas;



   [SerializeField]

    protected bool MoveFlg = false;

    private void Start()
    {
        //�v���C���[�L�����̏ꍇ�E�ɓ���
        if (character_id == 0) { target_direction = 1; }
        //�G�͍��Ɍ������ē���
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
        //Debug.Log("��ʌĂяo��");
       if(attack_Time < attack_Timing)return;

    }
    public void Damage(int dm)
    {
        Debug.Log("�U�����ꂽ�I"+this.gameObject.name);
        hp -= dm;
        DamageTxt(dm);
        if (hp <= 0) { Die(); }
    }
    private void DamageTxt(int dm)
    {

        //�ʒu�ݒ�
        Vector2 pos = new Vector2(Random.Range(transform.position.x-1,transform.position.x+1), 
            Random.Range(transform.position.y - 1, transform.position.y + 1));

        //TODO:03�@��x������������Ȃ�
        //�e�L�X�g�̐���
        Text damageIns = Instantiate(DamagePre, pos, Quaternion.identity, DamageCanvas.transform).GetComponent<Text>();
        //�e�L�X�g�̒l��ύX
        damageIns.text = dm.ToString();
    }

    protected virtual void Die()
    {
        if (scale.y > 0)
        {
            pos.y -= Time.deltaTime;
            scale.y -= Time.deltaTime;
            transform.position = pos;
            transform.localScale = scale;

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        MoveFlg = true;
        target = collision.gameObject.name;
        Debug.Log(target);
        Attack();
    }
}
