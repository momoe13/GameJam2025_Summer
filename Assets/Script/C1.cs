using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class C1: Character_Controller
{
    [SerializeField] int attackPower;
    bool targetFlg = true;
    Character_Controller controller;

    protected override void Attack()
    {
        //Debug.Log("攻撃！");
        //ターゲット名からターゲットとそのスクリプトを取得
        if(targetFlg)
        {
            controller = GameObject.Find(target).GetComponent<Character_Controller>();
            targetFlg = false;
        }

        //Damege関数呼び出し
        controller.Damage(attackPower);

    }

  
}
