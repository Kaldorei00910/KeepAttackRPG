using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    public string Name = "Test";
    public int MaxHp = 200;
    public int Hp = 200;
    public Enums.Grade ThisGrade = Enums.Grade.¿œπ›;
    public float Speed = 0.5f;

    public EnemyMovement Movement;

    public Slider HpBar;
    public TextMeshProUGUI HpText;
    public Animator animator;


    private void OnEnable()
    {
        Hp = MaxHp;
        Movement.isMoving = true;

        UpdateHpBar();
        Movement.StartAction(Speed);

    }


    public void OnDamaged()
    {
        Hp -= GameManager.Instance.Player.AtkDamage;
        if(Hp <= 0)
            OnDead();

        UpdateHpBar();

    }

    private void OnDead()
    {
        GameManager.Instance.Player.MonsterCollider = null;
        animator.SetBool("IsAttack", false);
        GameManager.Instance.MonsterDead();

        gameObject.SetActive(false);
    }


    private void UpdateHpBar()
    {
        HpBar.value = (float)Hp/MaxHp;
        HpText.text = $"{Hp}/{MaxHp}";
    }

    public void OnContacted()
    {
        Movement.StopMove();
        animator.SetBool("IsAttack", true);

    }

    private void OnMouseDown()
    {
        BattleUIManager.Instance.ChangeInfo(Name, ThisGrade.ToString(), Speed, MaxHp);
    }
}
