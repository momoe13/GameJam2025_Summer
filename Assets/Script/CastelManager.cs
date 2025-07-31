using System;
using UnityEngine;

public class CastelManager : MonoBehaviour
{
    [SerializeField] GameObject GameOver;
  
    public void GetCastel()
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
