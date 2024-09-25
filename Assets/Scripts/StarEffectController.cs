using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEffectController : MonoBehaviour
{
    Animator starAnimator;

    void Start()
    {
        starAnimator = GetComponent<Animator>();
    }

    public void PlayStarEffect()
    {
        starAnimator.SetTrigger("playStar");
    }

    public void DestroyEffectGameObject() // Animation Event
    {
        Destroy(gameObject);
    }
}
