using UnityEngine;
using UnityEngine.UI;

public class Boss:Character_Controller
{
    [SerializeField] GameObject Clar;
    protected override void Die()
    {
        base.Die();

        //死んだ
        Debug.Log("まだ動いてるよ");
        //クリアテキスト表示
        Clar.SetActive(true);
        Time.timeScale = 0.0f;
        //タイトルに遷移
        if(Input.GetMouseButtonDown(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("0_TitleScene");
            Time.timeScale = 1.0f;
        }
    }
}
