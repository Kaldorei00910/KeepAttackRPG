using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSO", menuName = "Monster", order = 1)]
public class MonsterSO : ScriptableObject
{
    public string Name;
    public int MaxHp;
    public float Speed;
    public Enums.Grade Grade;
    public RuntimeAnimatorController animatorController;
}
