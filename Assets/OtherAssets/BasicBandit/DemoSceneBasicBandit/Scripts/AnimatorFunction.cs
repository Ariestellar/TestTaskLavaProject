using UnityEngine;

public class AnimatorFunction : MonoBehaviour
{
	private Animator animator;

	private	void Awake () 
	{
		animator = GetComponent<Animator>();
	}

	public void Idle ()
	{
		animator.SetBool ("Walk", false);
		animator.SetBool ("SprintJump", false);
		animator.SetBool ("SprintSlide", false);
	}

	public void Walk ()
	{
		animator.SetBool ("Walk", true);
		animator.SetBool ("SprintJump", false);
		animator.SetBool ("SprintSlide", false);
	}

	public void SprintJump()
	{		
		animator.SetBool ("Walk", false);
		animator.SetBool ("SprintJump", true);
		animator.SetBool ("SprintSlide", false);
	}

	public void OnAiming()
	{		
		animator.SetBool("Aiming", true);		
	}

	public void OffAiming()
	{		
		animator.SetBool("Aiming", false);
	}	

	public void SprintSlide()
	{
		animator.SetBool ("Walk", false);
		animator.SetBool ("SprintJump", false);
		animator.SetBool ("SprintSlide", true);
	}
}
