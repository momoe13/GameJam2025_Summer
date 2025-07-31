using System;
using UnityEngine;

public class CastelManager : MonoBehaviour
{
    [SerializeField] GameObject GameOver;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("‚ ‚ ‚ ‚ ");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == ("Enemy"))
        {
            GameOver.SetActive(true);
            Time.timeScale = 0.0f;
            //ƒ^ƒCƒgƒ‹‚É‘JˆÚ
            if (Input.GetMouseButtonDown(0))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("0_TitleScene");
                Time.timeScale = 1.0f;
            }
        }
    }
}
