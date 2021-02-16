using UnityEngine;

public class ControllerAnimations : MonoBehaviour
{
	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void Idle()
	{
		animator.SetBool("Walk", false);		
	}

	public void Run()
	{
		animator.SetBool("Walk", true);		
	}

	public void OnAiming()
	{
		animator.SetBool("Aiming", true);
	}

	public void OffAiming()
	{
		animator.SetBool("Aiming", false);
	}
}
