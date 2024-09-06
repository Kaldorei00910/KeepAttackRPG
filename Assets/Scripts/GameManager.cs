using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    private Player _player;
    public Player Player { get { return _player; } set { _player = value; } }

    public int StageNum = 1;
    public ObjectPool ObjectPool;
    public BattleManager BattleManager;
    public GameObject WinPanel;



    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            ObjectPool = GetComponent<ObjectPool>();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void MonsterDead()
    {
        StageNum++;
        if(StageNum > 5)
        {
            GameWin();
        }
        else
        {
            BattleManager.CreateMonster(StageNum);
        }
    }

    public void GameWin()
    {
        Debug.Log("°ÔÀÓ½Â¸®");
        WinPanel.SetActive(true);
    }

}
