using UnityEngine;
using UnityEngine.UI;

public class Boss:Character_Controller
{
    [SerializeField] GameObject Clar;
    protected override void Die()
    {
        base.Die();

        //����
        Debug.Log("�܂������Ă��");
        //�N���A�e�L�X�g�\��
        Clar.SetActive(true);
        Time.timeScale = 0.0f;
        //�^�C�g���ɑJ��
        if(Input.GetMouseButtonDown(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("0_TitleScene");
            Time.timeScale = 1.0f;
        }
    }
}
