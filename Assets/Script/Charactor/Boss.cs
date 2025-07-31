using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss:Character_Controller
{
   GameObject Clear; 
    Vector2 pos, scale;//���S���[�V�����p�B
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
        { //�N���A�e�L�X�g�\��

            Clear = GameObject.Find("Clear");
            Clear.GetComponent<Text>().color = new Color(0.2f,0.2f,0.2f,1.0f);


            Time.timeScale = 0.0f;
            //�Q�[���I�[�o�[�ɑJ��
            if (Input.GetMouseButtonDown(0))
            {
                //1-1�ɑJ��
                if(SceneManager.GetActiveScene().name=="2_GameScene")
                {
                    Time.timeScale = 1.0f;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("3_GameScene");
                }
                else
                {
                    //�N���A��ʂɑJ��
                    SceneChange.GameClearLoadScene();
                }
            }
        }
       
    }
}
