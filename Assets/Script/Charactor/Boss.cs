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
        if(Clar != null)
        {
            Clar.SetActive(true);
        }

        Time.timeScale = 0.0f;
        //�Q�[���I�[�o�[�ɑJ��
        if(Input.GetMouseButtonDown(0))
        {
            SceneChange.GameClearLoadScene();
        }
    }
}
