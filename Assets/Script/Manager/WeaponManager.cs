
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    Character_Controller controller;
    Rigidbody2D rb;

    [SerializeField] int attackPower;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;
        if (velocity.sqrMagnitude > 0.01f) // ほぼ静止してない時だけ回転
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Z軸回転
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //替え
        // controller = GameObject.Find(collision.gameObject.name).GetComponent<Character_Controller>();
        if (collision.gameObject.TryGetComponent<Character_Controller>(out var controller))
        {
            controller.Damage(attackPower);
        }

        Destroy(this.gameObject);
    }
}
