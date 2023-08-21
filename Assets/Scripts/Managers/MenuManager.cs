using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject tooltips;
    public float duration = 2.0f;
    public void Showtooltips()
    {
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        tooltips.SetActive(true);
        yield return new WaitForSeconds(duration);
        tooltips.SetActive(value: false);
    }
}
