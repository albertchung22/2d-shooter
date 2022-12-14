using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator myAnim;
    public bool isAttacking = false;
    public bool isTaunting = false;
    public bool SwayForward = false;
    public bool SwayBackward = false;
    public bool BackwardAtk = false;
    public static PlayerCombat instance;
	public bool Grab2 = false;
	
	public Transform grabPoint;
	public float grabRange = 0.2f;
	public LayerMask enemyLayers;

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

        swayF();

        swayB();
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
			Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(grabPoint.position, grabRange, enemyLayers);
			foreach(Collider2D enemy in hitEnemies)
			{
				enemy.GetComponent<Enemy>().Grabbed();
			}	
		}
    } 

    private void swayF()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SwayForward = true;
            PlayerMovement.instance.animator.SetFloat("Speed", Mathf.Abs(0));
        }
    }

    private void swayB()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SwayBackward = true;
            PlayerMovement.instance.animator.SetFloat("Speed", Mathf.Abs(0));
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            BackwardAtk = true;
        }
    }
}
