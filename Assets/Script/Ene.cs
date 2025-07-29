using UnityEngine;

public class Ene: Character_Controller
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ƒvƒŒƒCƒ„[‚É“–‚½‚Á‚½");
        MoveFlg = true;
        target = collision.gameObject.name;
        Attack();
    }
}
