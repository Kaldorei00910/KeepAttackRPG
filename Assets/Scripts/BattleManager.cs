using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using static Enums;

public class BattleManager : MonoBehaviour
{
    public Transform SpawnLocationTransform;
    public List<RuntimeAnimatorController> MonsterAnimators = new List<RuntimeAnimatorController>();

    public TextAsset csvData;
    private string[] datas;
    private string[][] elements;

    private void Awake()
    {
        GameManager.Instance.BattleManager = this;
    }

    private void Start()
    {
        ParsingData();
        CreateMonster(GameManager.Instance.StageNum);
    }

    public void CreateMonster(int StageNum)
    {
        GameObject EnemyPrefab = GameManager.Instance.ObjectPool.SpawnFromPool("Enemy");
        Enemy enemy = EnemyPrefab.GetComponent<Enemy>();

        enemy.Name = elements[StageNum][0];
        enemy.ThisGrade = (Grade)Enum.Parse(typeof(Grade), elements[StageNum][1]);
        enemy.Speed = float.Parse(elements[StageNum][2]);
        enemy.MaxHp = int.Parse(elements[StageNum][3]);
        enemy.transform.position = SpawnLocationTransform.position;
        EnemyPrefab.GetComponentInChildren<Animator>().runtimeAnimatorController = MonsterAnimators[StageNum-1];
        EnemyPrefab.SetActive(true);
    }

    private void ParsingData()
    {
        int count = 0;
        datas = csvData.text.Split(new char[] { '\n' });
        elements = new string[datas.Length][];
        foreach (var data in datas)
        {
            elements[count] = data.Split(new char[] { ',' });
            count++;
        }
    }


}