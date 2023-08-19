using UnityEngine;

public class GameManager : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitalizeGameManager()
    {
        GameObject gameManagerObject = new GameObject("GameManager");
        gameManagerObject.AddComponent<GameManager>();
        DontDestroyOnLoad(gameManagerObject);
    }
}