using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Missile : MonoBehaviour
{
         //�ˏo�I�u�W�F�N�g
  [SerializeField] GameObject throwingObject;


  [SerializeField] GameObject targetObject;
  [SerializeField, Range(0f, 90f)] float throwingAngle;

    [SerializeField] float coolTime;
    float timer = 0;

    [Header("�U���͈�")]
    [SerializeField] float minDis;

    public IReadOnlyList<GameObject> activeEnemyList;
    private void Start()
    {
        //Find�Ŏ擾�͗ǂ��Ȃ��̂Ō�ŕύX���Ă�������
        activeEnemyList = GameObject.Find("GenerationManager").GetComponent<GenerationManager>().ActiveEnemyList;
    }

    void Update()
  {
        //���������ԋ߂�Enemy��T��

        //�^�[�Q�b�g�ɐݒ�


      timer += Time.deltaTime;
        if (timer > coolTime)
        {
            Attack();
            timer = 0;
        }
    }
    private void Attack()
    {
        //��++++++++++++��ԋ߂��G�T��++++++++++++��
        //  �^�OEnemy�̃I�u�W�F�N�g�����ׂĎ擾���A10f�ȓ��̍ł��߂��G�l�~�[���擾����B
        targetObject = null;    //�O��̍U���ň�ԋ߂������G�����Z�b�g
        float Min = minDis;    //�I�[�g�G�C���͈́B���D�݂ŁB
        foreach (GameObject enemy in activeEnemyList)    //�SEnemy�I�u�W�F�N�g����z����ЂƂÂ��[�v�B
        {
            if (enemy == null) { continue; }
            //�v���C���[�L�����ƃ��[�v���̓G�I�u�W�F�N�g�̋����������Z���č����o���B
            float dis = Vector3.Distance(transform.position, enemy.transform.position);                
            if (dis < Min)    //�I�[�g�G�C���͈�(10f)�ȓ����m�F
            {
                Min = dis;    //����Ƃ���ԋ߂��G�Ƃ̋����X�V�B���̃��[�v�p�B
                targetObject = enemy;    //����Ƃ���ԋ߂��G�I�u�W�F�N�g�X�V�B
                
            }
        }
        ThrowBall();
    }
  void ThrowBall()
  {
      if (throwingObject == null || targetObject == null) return;
      GameObject ball = Instantiate(throwingObject, transform.position, Quaternion.identity);
      Vector2 start = transform.position;
      Vector2 target = targetObject.transform.position;
      Vector2 vel = CalculateVelocity2D(start, target, throwingAngle);

      float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
        ball.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Z����]�i2D�j

        Rigidbody2D rb2d = ball.GetComponent<Rigidbody2D>();
      rb2d.AddForce(vel * rb2d.mass, ForceMode2D.Impulse);
  }

  Vector2 CalculateVelocity2D(Vector2 start, Vector2 target, float angleDeg) {
        float rad = angleDeg * Mathf.PI / 180f;
        float x = Vector2.Distance(new Vector2(start.x, 0), new Vector2(target.x, 0)); // ���������̋���
        float y = start.y - target.y;

        float gravity = Mathf.Abs(Physics2D.gravity.y); // 2D�����̏d�́i�ʏ�9.81�j

        float speedSq = gravity * x * x / (2 * Mathf.Cos(rad) * Mathf.Cos(rad) * (x * Mathf.Tan(rad) + y));

        if (float.IsNaN(speedSq) || speedSq < 0) return Vector2.zero;

        float speed = Mathf.Sqrt(speedSq);

        Vector2 dir = (target - start).normalized;
        dir.y = Mathf.Tan(rad);

        return dir.normalized * speed;
    }


}
