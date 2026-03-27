using UnityEngine;

[CreateAssetMenu(fileName = "BossData", menuName = "BossData")]
public class BossDataMaker : ScriptableObject
{
    [Header("ints")]
    public float BossHp;
    public float AttackRate;

}
