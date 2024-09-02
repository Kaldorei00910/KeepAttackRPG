using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Hp = 50000;
    public Enum.Grade grade = Enum.Grade.Normal;
    public float Speed = 0.5f;

    public Transform EnemyTransform;
    private Vector3 MoveVector;

    private bool isMoving = true;

    private void OnEnable()
    {
        isMoving = true;
        MoveVector = new Vector3(-Speed, 0, 0);
    }
    //private void Update()
    //{
    //    while (isMoving)
    //    {
    //        EnemyTransform.position -= MoveVector*Time.deltaTime;
    //    }
    //}


    //플레이어에게 공격받았을 때, 사망했을 때
    public void OnDamaged()
    {
        isMoving = false;

        Hp -= GameManager.Instance.Player.AtkDamage;
        Debug.Log(Hp);

        Debug.Log("피해받음");

        if(Hp < 0)
            OnDead();

    }

    private void OnDead()
    {
        GameManager.Instance.MonsterDead();
        gameObject.SetActive(false);
    }
}
