using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator myAnim;
	public bool isGrabbed = false;
	public static Enemy instance;
	
	// Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Grabbed()
	{
		Debug.Log("Enemy got griddied");
		isGrabbed = true;
	}
	
	private void Awake()
    {
        instance = this;
    }
}
