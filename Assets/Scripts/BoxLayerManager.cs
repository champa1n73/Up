using UnityEngine;

public class BoxLayerManager : MonoBehaviour
{
    [Header("Properties")]
    static int layerOrder = -1;

    [Header("Components")]
    SpriteRenderer boxSpriteRenderer;

    [Header("References")]
    [SerializeField] GameObject smokeEffect;


    void Start()
    {
        boxSpriteRenderer = GetComponent<SpriteRenderer>();
        smokeEffect.GetComponent<SpriteRenderer>().sortingOrder = ++layerOrder;
        boxSpriteRenderer.sortingOrder = ++layerOrder;
    }

    void Update()
    {
        if(smokeEffect != null)
        {
            smokeEffect.transform.rotation = Quaternion.Euler(0, 0 ,0);
        }
    }
}
