using UnityEngine;
using System.Collections;

public class MenuAnimations : MonoBehaviour {

	public Animator anim;
	public static MenuAnimations instance; 

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAnimation()
	{
		anim.Play ("WAIT01",-1,0f);
	}
}
