using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : PlayerComponent
{
    private Animator anim;

    public event Action AnimStartEvent;
    public event Action OnAnimEvent;
    public event Action AnimEndEvent;

    public override void InitCompo(PlayerController controller)
    {
        anim = GetComponent<Animator>();
    }

    public void SetTrigger(string propertyName)
    {
        anim.SetTrigger(propertyName);
    }

    public void SetBool(string propertyName, bool value)
    {
        anim.SetBool(propertyName, value);
    }

    public void SetLayerWeight(string layerName, float target)
    {
        anim.SetLayerWeight(anim.GetLayerIndex(layerName), target);
    }
    public Coroutine SetLayerWeight(string layerName, float start, float end, float time = 0)
    {
        return StartCoroutine(SetLayerWeightCo(layerName, start, end, time));
    }

    private IEnumerator SetLayerWeightCo(string layerName, float start, float end, float time)
    {
        float percent = 0;
        float value;

        while (percent < 1f)
        {
            percent += Time.deltaTime / time;
            value = Mathf.Lerp(start, end, percent);

            anim.SetLayerWeight(anim.GetLayerIndex(layerName), value);

            yield return null;
        }
    }

    public void InvokeAnimStartEvent() => AnimStartEvent?.Invoke();
    public void InvokeOnAnimEvent() => OnAnimEvent?.Invoke();
    public void InvokeAnimEndEvent() => AnimEndEvent?.Invoke();
}
