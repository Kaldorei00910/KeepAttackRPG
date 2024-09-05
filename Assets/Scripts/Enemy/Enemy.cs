using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string Name = "Test";
    public int MaxHp = 200;
    public int Hp = 200;
    public Enums.Grade Grade = Enums.Grade.¿œπ›;
    public float Speed = 0.5f;

    public EnemyMovement Movement;

    public Slider HpBar;
    public TextMeshProUGUI HpText;



    private void OnEnable()
    {
        Hp = MaxHp;
        Movement.isMoving = true;

        UpdateHpBar();
        Movement.StartAction(Speed);

    }


    public void OnDamaged()
    {
        Movement.StopMove(); 

        Hp -= GameManager.Instance.Player.AtkDamage;
        if(Hp <= 0)
            OnDead();

        UpdateHpBar();

    }

    private void OnDead()
    {
        GameManager.Instance.MonsterDead();
        GameManager.Instance.Player.MonsterCollider = null;
        gameObject.SetActive(false);
    }


    private void UpdateHpBar()
    {
        HpBar.value = (float)Hp/MaxHp;
        HpText.text = $"{Hp}/{MaxHp}";
    }
}
