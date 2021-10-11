using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystemManager : MonoBehaviour
{
    private GameObject inputFieldUsername, inputFieldPassword, toggleLogin, toggleCreate, buttonSubmit;
   
    GameObject networkedClient;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
        
        foreach (GameObject go in allObjects)
        {
            if (go.name == "InputFieldUsername")
                inputFieldUsername = go;
            else if (go.name == "InputFieldPassword")
                inputFieldPassword = go;
            else if (go.name == "ToggleLoging")
                toggleLogin = go;
            else if (go.name == "ToggleCreate")
                toggleCreate = go;
            else if (go.name == "ButtonSubmit")
                buttonSubmit = go;
            else if (go.name == "NetworkedClient")
                networkedClient = go;
        }
        buttonSubmit.GetComponent<Button>().onClick.AddListener(SubmitButtonPressed);
        toggleCreate.GetComponent<Toggle>().onValueChanged.AddListener(ToggleCreateValueChanged);
        toggleLogin.GetComponent<Toggle>().onValueChanged.AddListener(ToggleLogInValueChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitButtonPressed()
    {
        string n = inputFieldUsername.GetComponent<InputField>().text;
        string p = inputFieldPassword.GetComponent<InputField>().text;

        if (toggleLogin.GetComponent<Toggle>().isOn)
        {Debug.Log(ClientToSeverSignifiers.Login + "," + n + "," + p);
           // networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToSeverSignifiers.Login + "," + n + "," + p);
        }
        else
        {
            Debug.Log(ClientToSeverSignifiers.CreateAccount + "," + n + "," + p);
           // networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToSeverSignifiers.CreateAccount + "," + n + "," + p);
        }
    }

    public void ToggleCreateValueChanged(bool val)
    {
        toggleLogin.GetComponent<Toggle>().SetIsOnWithoutNotify(!val);
    }

    public void ToggleLogInValueChanged(bool val)
    {
        toggleCreate.GetComponent<Toggle>().SetIsOnWithoutNotify(!val);
    }

}

public static class ClientToSeverSignifiers
{
    public const int Login = 1;
    public const int CreateAccount = 2;
}

public static class ServertoClientSignifiers
{
    public const int LoginResponse = 1;

   /* public const int LoginFailure = 2;

    public const int CreateAccountSuccess = 1;
    public const int CreateAccountFailure = 2;*/

}

/*public static class LoginResponse
{
    public const int Success = 1;

    public const int FailureNameInUse = 2;

    public const int FailureNameNotFound = 3;

    public const int FailureIncorrectPassword = 4;
}*/
