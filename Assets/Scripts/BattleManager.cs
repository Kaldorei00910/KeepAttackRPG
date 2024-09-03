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
   
    private void Start()
    {
        ParsingData();
    }

    public void CreateMonster(int StageNum)
    {
        GameObject EnemyPrefab = GameManager.Instance.ObjectPool.SpawnFromPool("Enemy");
        Enemy enemy = EnemyPrefab.GetComponent<Enemy>();

        enemy.name = elements[StageNum][0];
        enemy.grade = (Grade)Enum.Parse(typeof(Grade), elements[StageNum][1]);
        enemy.Speed = int.Parse(elements[StageNum][2]);
        enemy.MaxHp = int.Parse(elements[StageNum][3]);

        enemy.transform.position = SpawnLocationTransform.position;
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