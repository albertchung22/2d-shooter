using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator myAnim;
    public bool isAttacking = false;
    public bool isTaunting = false;
    public static PlayerCombat instance;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

        Taunt();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            isAttacking = true;
        }
    }

    private void Taunt()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isTaunting = true;
        }
    }
}
