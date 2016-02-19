using UnityEngine;
using System.Collections;

public class CsFadeIn : MonoBehaviour
{
    public void Fade()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        CanvasGroup canvasgroup = GetComponent<CanvasGroup>();
        while (canvasgroup.alpha > 0) {
            canvasgroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        canvasgroup.interactable = false;
        yield return null;
    }
}