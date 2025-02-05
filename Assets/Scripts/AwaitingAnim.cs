using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwaitingAnim : MonoBehaviour
{
    [SerializeField] private Text _resultText;
    [SerializeField] private CompareNumber _compareNumberScript;
    private bool coroutineStarted;
    private Color textcolor;

    private void Awake()
    {
        textcolor = _resultText.color;
    }
    private void Update()
    {
        if (!_compareNumberScript.awaitingResult == false)
        {
            return;
        }

        if (coroutineStarted == false)
        {
            coroutineStarted = true;
            StartCoroutine(changeTextColor());
        }
    }

    private IEnumerator changeTextColor()
    {
        textcolor.a = 255;
        _resultText.color = textcolor;
        // Change Text Transparency to 255
        yield return new WaitForSeconds(0.8f);
        textcolor.a = 0;
        _resultText.color = textcolor;
        // Change Text Transparency to 0
        yield return new WaitForSeconds(0.4f);
        textcolor.a = 255;
        _resultText.color = textcolor;
        // Change Text Transparency to 255
        coroutineStarted = false;
    }
}
