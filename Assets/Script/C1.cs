using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class C1: Character_Controller
{
    [SerializeField] int attackPower;

    protected override void Attack()
    {
        //Debug.Log("�U���I");
        //�^�[�Q�b�g������^�[�Q�b�g�Ƃ��̃X�N���v�g���擾

        Character_Controller controller = GameObject.Find(target).GetComponent<Character_Controller>();

        //Damege�֐��Ăяo��
        controller.Damage(attackPower);

        //Die�֐��Ăяo��
        //Die();
    }

  
}
