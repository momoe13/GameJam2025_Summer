using UnityEngine;

public class SceneChange : MonoBehaviour
{
 

    public static void TitleLordScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("0_TitleScene");
        Time.timeScale = 1.0f;
    }
    
    public static void GameLordScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("2_GameScene");
        Time.timeScale = 1.0f;
    }
    
    public static void GameOverLordScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("2_ResultScene");
        Time.timeScale = 1.0f;
    }
}
