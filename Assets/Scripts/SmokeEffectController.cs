using UnityEngine;

public class SmokeEffectController : MonoBehaviour
{
    [Header("Components")]
    Animator myAnimator;

    [Header("Random Range")]
    [SerializeField] float anim_minSpeed = 1.5f;
    [SerializeField] float anim_maxSpeed = 2.5f;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void PlayEffect()
    {
        myAnimator.speed = Random.Range(anim_minSpeed, anim_maxSpeed);
        myAnimator.SetTrigger("ThrowSmoke");
    }

    public void DestroyEffectGameObject() // Animation Event
    {
        Destroy(gameObject);
    }
}
