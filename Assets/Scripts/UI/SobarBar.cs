using UnityEngine;
using UnityEngine.UI;

public class SobarBar : MonoBehaviour
{
    [SerializeField] private TwoParameterEventCenter<float, float> SobarChangeEventCenter;

    public Image sobarImage;

    private void OnEnable()
    {
        SobarChangeEventCenter.AddListener(OnSobarChangeEvent);
    }

    private void OnDisable()
    {
        SobarChangeEventCenter.RemoveListener(OnSobarChangeEvent);
    }

    private void OnSobarChangeEvent(float currentSobarValue, float maxSobarValue)
    {
        float persentage = currentSobarValue / maxSobarValue;
        OnSobarChange(persentage);
    }

    public void OnSobarChange(float persentage)
    {
        sobarImage.fillAmount = persentage;
    }
}