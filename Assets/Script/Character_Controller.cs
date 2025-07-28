using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField] int character_id;//���ʎq
    int target_direction;             //�i�s����

    [SerializeField] float      speed;//�ړ����x
    [SerializeField] float          hp;//�̗�

    [SerializeField] float attack_Timing;//�U���^�C�~���O
    float                   attack_Time;//�U���܂ł̃J�E���g�_�E���p�^�C��

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
