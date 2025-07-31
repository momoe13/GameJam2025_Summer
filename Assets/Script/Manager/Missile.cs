using Unity.VisualScripting;
using UnityEngine;

public class Missile : MonoBehaviour
{
         //射出オブジェクト
  [SerializeField] GameObject throwingObject;


  [SerializeField] GameObject targetObject;
  [SerializeField, Range(0f, 90f)] float throwingAngle;

  void Update()
  {
      if (Input.GetMouseButtonDown(0)) ThrowBall();
  }

  void ThrowBall()
  {
      if (throwingObject == null || targetObject == null) return;
      GameObject ball = Instantiate(throwingObject, transform.position, Quaternion.identity);
      Vector2 start = transform.position;
      Vector2 target = targetObject.transform.position;
      Vector2 vel = CalculateVelocity2D(start, target, throwingAngle);
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
