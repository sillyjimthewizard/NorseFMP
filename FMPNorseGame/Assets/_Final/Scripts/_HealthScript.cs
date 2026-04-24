using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _HealthScript : MonoBehaviour
{
   
    public bool isBoss;

    public ScriptableObject CurrentStats;
    public ScriptableObject[] BossStats;
    public BossDataMaker BossData;

    [SerializeField] private Image HealthSprite;
    [SerializeField] private TextMeshProUGUI HealthText;

    [Header("Floats")]
    public float Health;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void SetHp()
    {
        if (isBoss)
        {
            CurrentStats = BossStats[_GameManager.Instance.BossStage];
            BossData = (BossDataMaker)CurrentStats;
            Health = BossData.BossHp;
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
                _GameManager.Instance.BossStage++;
                SetHp();
            }
            else
            {
                Destroy(this.gameObject);
            }

        }

        UpdateHealthBar(BossData.BossHp, Health);
    }

    public void UpdateHealthBar(float maxhealth, float currenthealth)
    {
        HealthSprite.fillAmount = currenthealth / maxhealth;
        HealthText.text = currenthealth.ToString() + "/" + maxhealth.ToString();
    }


}
