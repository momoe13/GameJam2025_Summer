using UnityEngine;

public class GameClearManager : MonoBehaviour
{
    private void Update()
    {
        //クリックされたらタイトルに戻る
        if (Input.GetMouseButtonUp(0))
        {
            SceneChange.TitleLordScene();
        }
    }
}
