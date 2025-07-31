using UnityEngine;

public class Boss:Character_Controller
{
    protected override void Die()
    {
        base.Die();

        //死んだ
        Debug.Log("まだ動いてるよ");
        //クリアテキスト表示
     
        //タイトルに遷移
    }
}
