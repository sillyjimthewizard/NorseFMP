using UnityEngine;

public class _HealthScript : MonoBehaviour
{
    public int health;
    public bool isBoss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void Update()
    {

        if (health <= 0)
        {
            if (isBoss)
            {
                //KillBoss
            }
            else
            {
                //Kill me
            }

        }
    }




}
