using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int AtkDamage = 100;
    public float AtkSpd = 1.0f;
    private float radius = 0.5f;

    public Animator animator;
    public Collider2D MonsterCollider;

    private bool IsAnimating { get { return animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01"); } }

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
            MonsterCollider = Physics2D.OverlapCircle (this.gameObject.transform.position,radius,1<<6);

            if (MonsterCollider != null )
            {
                MonsterCollider.SendMessage("OnContacted", SendMessageOptions.DontRequireReceiver);
                animator.SetBool("IsIdle", false);
                animator.SetTrigger("PlayerAttackTrigger");

                while (IsAnimating)
                {
                    yield return null;
                }
                //애니메이션 이벤트를 통해 몬스터 공격
                animator.SetBool("IsIdle", true);
                yield return new WaitForSeconds(AtkSpd);
            }
            else
            {
                animator.SetBool("IsIdle", true);
                yield return null;
            }
        }
    }
}