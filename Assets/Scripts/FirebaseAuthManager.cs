using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;
using Firebase.Extensions;

public class FirebaseAuthManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseAuth user;

    public TMP_InputField email;
    public TMP_InputField password;
    public TextMeshProUGUI ResultTxt;

    // Start is called before the first frame update
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void Create()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWithOnMainThread(task =>
        {
            ResultTxt.text = "������";

            if (task.IsCanceled)
            {
                ResultTxt.text = "�������";

                return;
            }
            if (task.IsFaulted)
            {
                ResultTxt.text = "���Խ���";

                return;
            }
            FirebaseUser newUser = task.Result.User;
            ResultTxt.text = "���ԿϷ�";
        });
    }
    public void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWithOnMainThread(task =>
        {
            ResultTxt.text = "�α�����";

            if (task.IsCanceled)
            {
                ResultTxt.text = "�α������";

                return;
            }
            if (task.IsFaulted)
            {
                ResultTxt.text = "�α��ν���";

                return;
            }
            FirebaseUser newUser = task.Result.User;
            ResultTxt.text = $"�α��� �Ϸ�\n����� ������ȣ = {newUser.UserId}";

        });
    }

    public void LogOut()
    {
        auth.SignOut();
        ResultTxt.text = "�α׾ƿ�";

    }

}
