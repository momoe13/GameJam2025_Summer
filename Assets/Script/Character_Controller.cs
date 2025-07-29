using Unity.VisualScripting;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField] int character_id;//���ʎq
    int target_direction;             //�i�s����

    [SerializeField] float      speed;//�ړ����x
    [SerializeField] float          hp;//�̗�

    [SerializeField] float attack_Timing;//�U���^�C�~���O
    float                   attack_Time;//�U���܂ł̃J�E���g�_�E���p�^�C��
    protected string            target;//�U������I�u�W�F�N�g


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
        Die();
    }
    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("������");
        MoveFlg = true;
        target = collision.gameObject.name;
        Debug.Log(target);
        Attack();
    }
}
