using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void GameStart()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
