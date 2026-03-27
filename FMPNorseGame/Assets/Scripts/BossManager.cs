using UnityEngine;

public class BossManager : MonoBehaviour
{
    public ScriptableObject[] BossStats;
    // 0 = Ratatoskr 1 = audhumbla 2 = World Serpent 3 = fenrir 4 = odin 

    public static BossManager instance;
    public ScriptableObject CurrentStats;

    [Header("Floats")]
    public float BossHp;
    public int BossStage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        SetBossStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (BossHp <= 0)
        {
            Debug.Log("Woah you won");
        }
    }

    public void SetBossStats()
    {
        BossDataMaker tempBossdata;
        CurrentStats = BossStats[BossStage];
        tempBossdata = (BossDataMaker)CurrentStats;
        BossHp = tempBossdata.BossHp;
        BossStage++;
    }
}
