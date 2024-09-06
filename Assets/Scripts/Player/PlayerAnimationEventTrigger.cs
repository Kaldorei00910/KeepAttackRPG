using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventTrigger : MonoBehaviour
{
    public void OnAttackEvent()
    {
        if(GameManager.Instance.Player.MonsterCollider != null)
        {
            GameManager.Instance.Player.MonsterCollider.SendMessage("OnDamaged", SendMessageOptions.DontRequireReceiver);

        }
    }

}
