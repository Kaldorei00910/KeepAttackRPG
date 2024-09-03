using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool isMoving = true;

    private void OnEnable()
    {
        isMoving = true;
        
    }

    public void StartAction(float speed)
    {
        StartCoroutine(ActionSequence(speed));
    }
    private IEnumerator ActionSequence(float speed)
    {
        while (isMoving)//�̵� ��Ȳ
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            yield return null;
        }
        //������Ȳ(�÷��̾� ���ݻ�Ȳ)
        yield return null;
    }

    public void StopMove()
    {
        isMoving = false;
    }
}
