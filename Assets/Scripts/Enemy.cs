using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Hp = 50;
    public Enum.Grade grade = Enum.Grade.Normal;
    public float Speed = 0.5f;

    private Vector3 MoveVector = Vector3.left;

    private bool isMoving = true;

    private void OnEnable()
    {
        isMoving = true;
        StartCoroutine(ActionSequence());

    }
    
    private IEnumerator ActionSequence()
    {
        while (isMoving)//이동 상황
        {
            transform.position += MoveVector * Speed * Time.deltaTime;
            yield return null;
        }
        //정지상황(플레이어 공격상황)
        yield return null;

    }


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
