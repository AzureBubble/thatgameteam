using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private OneParamaterEventCenter<float> FadeEventCenter;
    [SerializeField] private TwoParameterEventCenter<string, Vector3> StringVector3EventCenter;
    [SerializeField] private OneParamaterEventCenter<Vector3> MoveToPositionEventCenter;
    [SerializeField] private VoidEventCenter BeforeSceneUnLoadEventCenter;
    [SerializeField] private VoidEventCenter AfterSceneLoadedEventCenter;
    [SerializeField] private VoidEventCenter NewGameEventCenter;
    [SerializeField] private VoidEventCenter QuitGameEventCenter;
    [SerializeField] private VoidEventCenter InitiazationEventCenter;

    [SerializeField] private float fadeDuration = 1.5f;
    [SerializeField] private GameObject sobarBar;

    private CanvasGroup fadeCanvasGroup;

    [SerializeField] private string startSceneName = "Menu";
    [SerializeField] private string firstSceneName = "Test_qzj";
    [SerializeField] private Vector3 firstPos;
    private bool isFade;

    private void Awake()
    {
        fadeCanvasGroup = FindObjectOfType<CanvasGroup>();
    }

    private void OnEnable()
    {
        BeforeSceneUnLoadEventCenter.AddListener(OnBeforeSceneUnLoadEvent);
        AfterSceneLoadedEventCenter.AddListener(OnAfterSceneLoadedEvent);
        StringVector3EventCenter.AddListener(OnTransitionEvent);
        NewGameEventCenter.AddListener(NewGame);
        QuitGameEventCenter.AddListener(QuitGame);
        //InitiazationEventCenter.AddListener(OnInitiazationEvent);
    }

    private IEnumerator Start()
    {
        yield return LoadSceneSetActive(startSceneName);

        if (startSceneName != "Menu")
            AfterSceneLoadedEventCenter.RaiseEvent();
    }

    private void OnDisable()
    {
        BeforeSceneUnLoadEventCenter.RemoveListener(OnBeforeSceneUnLoadEvent);
        AfterSceneLoadedEventCenter.RemoveListener(OnAfterSceneLoadedEvent);

        StringVector3EventCenter.RemoveListener(OnTransitionEvent);
        NewGameEventCenter.RemoveListener(NewGame);
        QuitGameEventCenter.RemoveListener(QuitGame);
        //InitiazationEventCenter.RemoveListener(OnInitiazationEvent);
    }

    private void OnBeforeSceneUnLoadEvent()
    {
        SetSobarInVisiable();
    }

    private void OnAfterSceneLoadedEvent()
    {
        SetSobarVisiable();
    }

    private void SetSobarInVisiable()
    {
        sobarBar.SetActive(false);
    }
    private void SetSobarVisiable()
    {
        sobarBar.SetActive(true);
    }

    private void OnTransitionEvent(string sceneName, Vector3 targetPos)
    {
        if (!isFade)
            StartCoroutine(SwitchScene(sceneName, targetPos));
    }

    private void NewGame()
    {
        if (!isFade)
            StartCoroutine(SwitchScene(firstSceneName, firstPos));
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

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}