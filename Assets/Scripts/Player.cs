using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int AtkDamage = 100;
    public float AtkSpd = 1.0f;
    private float radius = 0.5f;
    private void Awake()
    {
        GameManager.Instance.Player = this;
    }

    private void Start()
    {
        StartCoroutine(AttackStance());
    }

    IEnumerator AttackStance()
    {
        while (true)
        {
            Collider2D MonsterCollider = Physics2D.OverlapCircle(this.gameObject.transform.position,radius,1<<6);
            if (MonsterCollider != null )
            {
                MonsterCollider.SendMessage("OnDamaged", SendMessageOptions.DontRequireReceiver);

                yield return new WaitForSeconds(AtkSpd);
            }
            else
            {
                yield return null;
            }
        }

    }
}