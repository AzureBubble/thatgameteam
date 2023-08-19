using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private OneParamaterEventCenter<float> FadeEventCenter;
    [SerializeField] private TwoParameterEventCenter<string, Vector3> StringVector3EventCenter;
    [SerializeField] private VoidEventCenter BeforeSceneUnLoadEventCenter;
    [SerializeField] private VoidEventCenter AfterSceneLoadedEventCenter;
    [SerializeField] private OneParamaterEventCenter<Vector3> MoveToPositionEventCenter;

    [SerializeField] private float fadeDuration = 1.5f;
    private CanvasGroup fadeCanvasGroup;

    [SerializeField] private string startSceneName = "Test_qzj";
    private bool isFade;

    private void Awake()
    {
        fadeCanvasGroup = FindObjectOfType<CanvasGroup>();
    }

    private void OnEnable()
    {
        StringVector3EventCenter.AddListener(OnTransitionEvent);
    }

    private IEnumerator Start()
    {
        yield return LoadSceneSetActive(startSceneName);
        AfterSceneLoadedEventCenter.RaiseEvent();
    }

    private void OnDisable()
    {
        StringVector3EventCenter.RemoveListener(OnTransitionEvent);
    }

    private void OnTransitionEvent(string sceneName, Vector3 targetPos)
    {
        if (!isFade)
            StartCoroutine(SwitchScene(sceneName, targetPos));
    }

    private void LoadSceneEvent(string sceneName, Vector3 targetPos)
    {
        if (!isFade)
        {
        }
    }

    private IEnumerator LoadSceneSetActive(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
    }

    private IEnumerator SwitchScene(string scenaName, Vector3 targetPos)
    {
        BeforeSceneUnLoadEventCenter.RaiseEvent();

        yield return Fade(1);

        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        yield return LoadSceneSetActive(scenaName);

        MoveToPositionEventCenter.RaisedEvent(targetPos);

        yield return Fade(0);

        AfterSceneLoadedEventCenter.RaiseEvent();
    }

    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;
        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;
        isFade = false;
    }
}