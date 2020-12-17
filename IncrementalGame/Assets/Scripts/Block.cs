using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private float health = 5.0f;

    private string blockType;

    private bool colliding = false;

    private Player player;

    // Represents the time between attacks from the player.
    private float damageTime;

    private float damageTimeRemaining = -1.0f;

    private bool damageTimerRunning = false;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        damageTime = player.GetAttackSpeed();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (colliding)
        {
            if (player.CanAttack())
            {
                health -= player.GetDamage();
                Debug.Log("Block attacked, health: " + health);
                player.Attacked();
                if (health <= 0)
                {
                    player.KilledBlock(this);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject c = collision.gameObject;

        if (c.tag == "Player")
        {
            colliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject c = collision.gameObject;

        if (c.tag == "Player")
        {
            colliding = false;
        }
    }
}