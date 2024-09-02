using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    GameObject EnemyPrefab;


    public void CreateMonster(int StageNum)
    {
        EnemyPrefab = GameManager.Instance.ObjectPool.SpawnFromPool("Enemy");

    }

    private void ParsingData()
    {

    }


}
