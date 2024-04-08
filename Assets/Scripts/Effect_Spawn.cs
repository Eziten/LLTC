using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Effect_Spawn : MonoBehaviour
{
    Sequence sequence;
    SpriteRenderer spriteRenderer;

    Color[] Colors = new Color[2] { new Color32(255, 135, 135, 255), new Color32(255, 0, 0, 255) };

    // Start is called before the first frame update
    void Start()
    {
        sequence = DOTween.Sequence().SetAutoKill(false).OnComplete(TweenEnd);
        spriteRenderer = transform.GetComponent<SpriteRenderer>();

        sequence.Append(spriteRenderer.DOColor(Colors[0], 0.1f)).
                 Append(spriteRenderer.DOColor(Colors[1], 0.1f)).SetLoops(6);     
    }

    void TweenEnd()
    {
        EffectSpawner.Instance.PushToPool("Effect_Spawn", gameObject);
    }

    private void OnEnable()
    {
        sequence.Restart();
    }
}
