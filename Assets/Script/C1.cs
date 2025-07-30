using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class C1: Character_Controller
{
    [SerializeField] int attackPower;

    protected override void Attack()
    {
        //Debug.Log("攻撃！");
        //ターゲット名からターゲットとそのスクリプトを取得

        Character_Controller controller = GameObject.Find(target).GetComponent<Character_Controller>();

        //Damege関数呼び出し
        controller.Damage(attackPower);

        //Die関数呼び出し
        //Die();
    }

  
}
