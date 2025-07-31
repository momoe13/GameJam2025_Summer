using Unity.VisualScripting;
using UnityEngine;

public class Missile : MonoBehaviour
{
         //射出オブジェクト
  [SerializeField] GameObject throwingObject;


  [SerializeField] GameObject targetObject;
  [SerializeField, Range(0f, 90f)] float throwingAngle;

    [SerializeField] float coolTime;
    float timer = 0;

    [Header("攻撃範囲")]
    [SerializeField] float minDis;

    

    void Update()
  {
        //自分から一番近いEnemyを探す

        //ターゲットに設定


      timer += Time.deltaTime;
        if (timer > coolTime)
        {
            Attack();
            timer = 0;
        }
    }
    private void Attack()
    {
        //↓++++++++++++一番近い敵探し++++++++++++↓
        //  タグEnemyのオブジェクトをすべて取得し、10f以内の最も近いエネミーを取得する。
        targetObject = null;    //前回の攻撃で一番近かった敵をリセット
        minDis = 10f;    //オートエイム範囲。お好みで。
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");//Enemyタグがついたオブジェクトをすべて配列に格納。
        foreach (GameObject enemy in enemys)    //全Enemyオブジェクト入り配列をひとつづつループ。
        {
            //プレイヤーキャラとループ中の敵オブジェクトの距離を引き算して差を出す。
            float dis = Vector3.Distance(transform.position, enemy.transform.position);                
            if (dis < minDis)    //オートエイム範囲(10f)以内か確認
            {
                minDis = dis;    //今んとこ一番近い敵との距離更新。次のループ用。
                targetObject = enemy;    //今んとこ一番近い敵オブジェクト更新。
                ThrowBall();
            }
        }
    }
  void ThrowBall()
  {
      if (throwingObject == null || targetObject == null) return;
      GameObject ball = Instantiate(throwingObject, transform.position, Quaternion.identity);
      Vector2 start = transform.position;
      Vector2 target = targetObject.transform.position;
      Vector2 vel = CalculateVelocity2D(start, target, throwingAngle);

      float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
        ball.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Z軸回転（2D）

        Rigidbody2D rb2d = ball.GetComponent<Rigidbody2D>();
      rb2d.AddForce(vel * rb2d.mass, ForceMode2D.Impulse);
  }

  Vector2 CalculateVelocity2D(Vector2 start, Vector2 target, float angleDeg) {
        float rad = angleDeg * Mathf.PI / 180f;
        float x = Vector2.Distance(new Vector2(start.x, 0), new Vector2(target.x, 0)); // 水平方向の距離
        float y = start.y - target.y;

        float gravity = Mathf.Abs(Physics2D.gravity.y); // 2D物理の重力（通常9.81）

        float speedSq = gravity * x * x / (2 * Mathf.Cos(rad) * Mathf.Cos(rad) * (x * Mathf.Tan(rad) + y));

        if (float.IsNaN(speedSq) || speedSq < 0) return Vector2.zero;

        float speed = Mathf.Sqrt(speedSq);

        Vector2 dir = (target - start).normalized;
        dir.y = Mathf.Tan(rad);

        return dir.normalized * speed;
    }


}
