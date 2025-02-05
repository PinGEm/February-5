using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorGUI : MonoBehaviour
{
    [SerializeField] private GameObject errorGUI;
    public void Exit()
    {
        errorGUI.SetActive(false);
    }
}
