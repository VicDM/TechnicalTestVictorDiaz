using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class LoginManager : MonoBehaviour
{
    [SerializeField]private TMP_InputField _emailField;
    [SerializeField]private TMP_InputField _passwordField;
    [SerializeField]private Toggle _passwordToggle;
    [SerializeField]private TMP_Text _errorText;
    [SerializeField]private Button _loginButton;

    void OnEnable()
    {
        EventManager.OnUserDataLoaded += UpdateUIData;
        EventManager.OnUserDataSaved += SaveFinished;
    }

    void OnDisable()
    {
        EventManager.OnUserDataLoaded -= UpdateUIData;
        EventManager.OnUserDataSaved -= SaveFinished;
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _loginButton.onClick.AddListener(Login);
        _passwordToggle.onValueChanged.AddListener(PasswordVisibility);

        EventManager.RequestLoad();
    }

    void UpdateUIData()
    {
        _emailField.text = PlayerData.userData.userEmail;
        _passwordField.text = PlayerData.userData.userPassword;
    }

    void Login()
    {
        if(!IsEmailValid(_emailField.text))
        {
            ShowError("Invalid email address");
            return;
        }

        if(!IsPasswordValid(_passwordField.text))
        {
            ShowError("Invalid password");
            return;
        }

        SaveLoginInfo();

        _errorText.text = "";
        _loginButton.interactable = false;
    }

    void SaveLoginInfo()
    {
        PlayerData.userData.userEmail = _emailField.text;
        PlayerData.userData.userPassword = _passwordField.text;

        //SavingDataSystem.Save();
        EventManager.RequestSave();
    }

    void SaveFinished()
    {
        EventManager.RequestScene(1);
    }

    bool IsEmailValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) 
        {
            return false;
        }

        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    bool IsPasswordValid(string password)
    {
        return !string.IsNullOrWhiteSpace(password);
    }

    void PasswordVisibility(bool toggleStatus)
    {
        //bool value inverted because when the toggle is on the password is shown
        if(!toggleStatus)
        {
            _passwordField.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            _passwordField.contentType = TMP_InputField.ContentType.Password;
        }

        _passwordField.ForceLabelUpdate();
    }

    void ShowError(string errorMessage)
    {
        if(_errorText != null)
        {
            _errorText.text = errorMessage;
        }
    }
}