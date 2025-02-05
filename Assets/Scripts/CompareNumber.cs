using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CompareNumber : MonoBehaviour
{
    [SerializeField] private InputField _firstInputField;
    [SerializeField] private InputField _secondInputField;
    [SerializeField] private Text _resultText;
    [HideInInspector] public bool awaitingResult = false;

    public void CompareNumbers()
    {
        awaitingResult = true;
        _resultText.text = "Please Enter a Valid Number";
        if (!float.TryParse(_firstInputField.text, out float firstInput))
        {
            return;
        }

        if (!float.TryParse(_secondInputField.text, out float secondInput))
        {
            return;
        }



        if (firstInput > secondInput)
        {
            _resultText.text = "The First Input is Greater than the Second Input";
        }
        else if (secondInput > firstInput)
        {
            _resultText.text = "The Second Input is Greater than the First Input";
        }
        else { _resultText.text = "Both Statements are Equal"; }
    }
}
