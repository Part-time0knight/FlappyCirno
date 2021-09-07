using System.Collections;
using UnityEngine;

public class PlayerView : MonoBehaviour, IViewController
{
    private Animator animator;

    private bool _freeze = false;
    public bool freeze
    {
        get { return _freeze; }
        set
        {
            _freeze = value;
            if (value)
                animator.speed = 0;
            else
                animator.speed = 1;
        }
    }
    private bool flyMod = false;
    public bool PlayFly { get { return flyMod; }
        set
        {
            flyMod = value;
            string animation = "fly";
            animator.SetBool(animation, value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayJump()
    {
        string animation = "jump";
        animator.SetBool(animation, true);
        StartCoroutine(AnimatorReset(animation));
    }

    private IEnumerator AnimatorReset(string animation)
    {
        yield return new WaitForEndOfFrame();
        animator.SetBool(animation, false);
        PlayFly = false;
    }

    public void PlayFall()
    { 
        string animation = "fall";
        animator.SetBool(animation, true);
        StartCoroutine(AnimatorReset(animation));
    }
}
