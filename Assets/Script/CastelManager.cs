using System;
using UnityEngine;

public class CastelManager : MonoBehaviour
{
    [SerializeField] GameObject GameOver;
    bool EndFlg=false;
  
    public void CastelDamage()
    {
        Debug.Log("é‚¾‚æ`");
        GameOver.SetActive(true);
        Time.timeScale = 0.0f;
        EndFlg = true;
    }
    private void Update()
    {
        //ƒ^ƒCƒgƒ‹‚É‘JˆÚ
        if (EndFlg&& Input.GetMouseButtonDown(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("0_TitleScene");
            Time.timeScale = 1.0f;
        }
    }
}
