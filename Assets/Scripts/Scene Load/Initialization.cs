using UnityEngine;
using UnityEngine.SceneManagement;

public class Initialization : MonoBehaviour
{
    [SerializeField] private VoidEventCenter InitiazationEventCenter;

    private void Awake()
    {
        SceneManager.LoadSceneAsync("Persistence");
        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
    }
}