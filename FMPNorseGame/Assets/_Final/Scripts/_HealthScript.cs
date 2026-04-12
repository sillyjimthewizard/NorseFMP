using UnityEngine;

public class _HealthScript : MonoBehaviour
{
   
    public bool isBoss;

    public ScriptableObject CurrentStats;
    public ScriptableObject[] BossStats;

    [Header("Floats")]
    public float Health;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void SetHp()
    {
        if (isBoss)
        {
            BossDataMaker tempBossdata;
            CurrentStats = BossStats[_GameManager.Instance.BossStage];
            tempBossdata = (BossDataMaker)CurrentStats;
            Health = tempBossdata.BossHp;
        }
        else
        {
            
        }

    }

    public void Start()
    {
        SetHp();
    }

    private void Update()
    {

        if (Health <= 0)
        {
            if (isBoss)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }

        }
    }




}
