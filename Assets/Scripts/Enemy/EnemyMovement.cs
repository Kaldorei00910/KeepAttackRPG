using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool isMoving = true;

    public void StartAction(float speed)
    {
        StartCoroutine(ActionSequence(speed));
    }
    private IEnumerator ActionSequence(float speed)
    {
        while (isMoving)//이동 상황
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            yield return null;
        }
        //정지상황(플레이어 공격상황)
        yield return null;
    }

    public void StopMove()
    {
        isMoving = false;
    }

}
