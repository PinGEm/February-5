using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentDataManager : MonoBehaviour
{
    public InputField _nameInput;
    public InputField _ageInput;
    public InputField _studentNumberInput;
    public InputField _sectionInput;

    public InputField _searchInput;
    public Text _resultText;

    [SerializeField] private GameObject _errorGUI;
    public void SaveStudentData()
    {
        string studentName = _nameInput.text;
        int age;
        int studentNumber;
        string section = _sectionInput.text;

        if (string.IsNullOrEmpty(studentName) || string.IsNullOrEmpty(section) || !int.TryParse(_ageInput.text, out age) || !int.TryParse(_studentNumberInput.text, out studentNumber))
        {
            _errorGUI.SetActive(true);
            Debug.Log("EXCEPTION ERROR: Please ensure all your values are set properly.");
            return;
        }

        // Save Data in PlayPrefs
        PlayerPrefs.SetString(studentName + "Section", section);
        PlayerPrefs.SetInt(studentName + "Age", age);
        PlayerPrefs.SetInt(studentName + "Student Number", studentNumber);
        PlayerPrefs.Save();

        Debug.Log("Student Data is Safely Saved for: " + studentName);
    }

    public void LoadStudentData()
    {
        string studentName = _searchInput.text;
        if (PlayerPrefs.HasKey(studentName + "Age"))
        {
            int age = PlayerPrefs.GetInt(studentName + "Age");
            int studentNumber = PlayerPrefs.GetInt(studentName + "Student Number");
            string section = PlayerPrefs.GetString(studentName + "Section");

            _resultText.text = $"Name: {studentName}\nAge:{age}\nSN:{studentNumber}\nSection:{section}";
        }
        else
        {
            _errorGUI.SetActive(true);
            _resultText.text = "Student Not Found...";
        }
    }
}
