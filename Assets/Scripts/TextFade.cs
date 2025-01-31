using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Collections;

public class TextFade : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textDisplay = null;

    private bool isFading = false;
    //private Sequence colorLoop = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textDisplay = GetComponent<TMP_Text>();
        //Tween colorShift0 = textDisplay.DOColor(new Color(1, 1, 1, 1), 1.0f);
        //Tween colorShift1 = textDisplay.DOColor(Color.cyan, 1.0f);
        //colorLoop = DOTween.Sequence();
        //colorLoop.Append(colorShift0);
        //colorLoop.Append(colorShift1);
        //colorLoop.SetLoops(-1);
        //colorLoop.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !isFading)
        {
            FadeText();
        }
    }

    private void FadeText()
    {
        isFading = true;

        StartCoroutine(DoFading());
    }

    IEnumerator DoFading()
    {
        //colorLoop.Kill();
        Tween fadeText = textDisplay.DOFade(0, 1.0f);
        yield return fadeText.WaitForCompletion();

        isFading=false;
        enabled = false;
    }
}
