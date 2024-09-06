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
            ResultTxt.text = "가입중";

            if (task.IsCanceled)
            {
                ResultTxt.text = "가입취소";

                return;
            }
            if (task.IsFaulted)
            {
                ResultTxt.text = "가입실패";

                return;
            }
            FirebaseUser newUser = task.Result.User;
            ResultTxt.text = "가입완료";
        });
    }
    public void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWithOnMainThread(task =>
        {
            ResultTxt.text = "로그인중";

            if (task.IsCanceled)
            {
                ResultTxt.text = "로그인취소";

                return;
            }
            if (task.IsFaulted)
            {
                ResultTxt.text = "로그인실패";

                return;
            }
            FirebaseUser newUser = task.Result.User;
            ResultTxt.text = $"로그인 완료\n당신의 고유번호 = {newUser.UserId}";

        });
    }

    public void LogOut()
    {
        auth.SignOut();
        ResultTxt.text = "로그아웃";

    }

}
