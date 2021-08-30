using System.Collections;
using UnityEngine;

public class PlayerView : MonoBehaviour, IViewController
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayJump()
    {
        animator.SetBool("jump", true);
        StartCoroutine(ObjReset());
    }

    private IEnumerator ObjReset()
    {
        yield return new WaitForEndOfFrame();
        animator.SetBool("jump", false);
    }
}
