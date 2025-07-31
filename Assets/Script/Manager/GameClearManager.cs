using UnityEngine;

public class GameClearManager : MonoBehaviour
{
    private void Update()
    {
        //クリックされたらタイトルに戻る
        if (Input.GetMouseButton(0))
        {
            SceneChange.TitleLordScene();
        }
    }
}
