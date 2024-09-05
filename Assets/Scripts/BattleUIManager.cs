using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleUIManager : MonoBehaviour
{

    public TextMeshProUGUI InformationTxt;

    public static BattleUIManager _instance;

    public static BattleUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("BattleUIManager").AddComponent<BattleUIManager>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

        }
        else
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
        }
    }

    public void ChangeInfo(string name, string grade, float speed, float health)
    {
        InformationTxt.text = $"이름 : {name}\r\n등급 : {grade}\r\n속도 : {speed}\r\n체력 : {health}";
    }

}
