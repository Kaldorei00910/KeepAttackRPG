using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventTrigger : MonoBehaviour
{
    public void OnAttackEvent()
    {
        GameManager.Instance.Player.MonsterCollider.SendMessage("OnDamaged", SendMessageOptions.DontRequireReceiver);
    }

}
