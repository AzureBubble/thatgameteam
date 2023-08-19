using UnityEngine;
using UnityEngine.SceneManagement;

public class Initialization : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadSceneAsync("Persistence");
        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
    }
}