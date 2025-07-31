using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss:Character_Controller
{
   GameObject Clear; 
    Vector2 pos, scale;//死亡モーション用。
    protected override void Die()
    {
        base.Die();
        if (scale.y > 0)
        {
            pos = transform.position;
            pos.y -= Time.deltaTime;
            scale.y -= Time.deltaTime;
            transform.position = pos;
            transform.localScale = scale;

        }
        else
        { //クリアテキスト表示

            Clear = GameObject.Find("Clear");
            Clear.GetComponent<Text>().color = new Color(0.2f,0.2f,0.2f,1.0f);


            Time.timeScale = 0.0f;
            //ゲームオーバーに遷移
            if (Input.GetMouseButtonDown(0))
            {
                //1-1に遷移
                if(SceneManager.GetActiveScene().name=="2_GameScene")
                {
                    Time.timeScale = 1.0f;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("3_GameScene");
                }
                else
                {
                    //クリア画面に遷移
                    SceneChange.GameClearLoadScene();
                }
            }
        }
       
    }
}
