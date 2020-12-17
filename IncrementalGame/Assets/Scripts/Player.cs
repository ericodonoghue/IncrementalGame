using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // This represents the base damage before multipliers are applied.
    [SerializeField]
    [Header("Damage")]
    private float baseDamage = 1.0f;

    // This represents damage after multiplers applied.
    [SerializeField]
    private float finalDamage = 1.0f;

    // Multipliers from prestige upgrades.
    [SerializeField]
    private float prestigeDmgMultiplier = 1.0f;

    // Multipliers from the current run.
    [SerializeField]
    private float runDmgMultiplier = 1.0f;

    // This is set to true when the multipliers are changed and damage needs to be recalculated.
    private bool damageUpdated = true;

    // This represents the base attack speed before multipliers are applied.
    // This represents the time in seconds between attacks.
    // Multipliers will decrease the attack speed value
    [SerializeField]
    [Header("Attack Speed")]
    private float baseAttackSpeed = 1.0f;

    [SerializeField]
    private float finalAttackSpeed = 1.0f;

    [SerializeField]
    private float runAtkSpeedMult = 1.0f;

    [SerializeField]
    private float prestigeAtkSpeedMult = 1.0f;

    private bool attackSpeedUpdated = true;

    [SerializeField]
    [Header("Money")]
    private int Money = 0;

    //   private 2Dbox
    // Start is called before the first frame update
    private void Start()
    {
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public float GetDamage()
    {
        if (damageUpdated)
        {
            finalDamage = baseDamage * prestigeDmgMultiplier * runDmgMultiplier;
            damageUpdated = false;
        }
        return finalDamage;
    }

    public float GetAttackSpeed()
    {
        if (attackSpeedUpdated)
        {
            finalAttackSpeed = baseAttackSpeed * prestigeAtkSpeedMult * runAtkSpeedMult;
            attackSpeedUpdated = false;
        }
        return finalAttackSpeed;
    }

    /// <summary>
    /// This will handle the rewards for the player killing enemy.
    /// </summary>
    /// <param name="block"></param>
    public void KilledBlock(Block block)
    {
        Money++;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 pos = transform.position;
        Vector3 temp = Input.mousePosition;
        temp.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(temp);

        this.transform.position = mousePos;
    }
}