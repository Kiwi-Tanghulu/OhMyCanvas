using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : PlayerComponent
{
    private Animator anim;

    public Action AnimStartEvent;
    public Action OnAnimEvent;
    public Action AnimEndEvent;

    public override void InitCompo(PlayerController controller)
    {
        anim = transform.Find("Visual").GetComponent<Animator>();
    }

    public void SetTriggerProperty(string propertyName)
    {
        anim.SetTrigger(propertyName);
    }

    public void SetAnimBoolProperty(string propertyName, bool value)
    {
        anim.SetBool(propertyName, value);
    }

    public void InvokeAnimStartEvent() => AnimStartEvent?.Invoke();
    public void InvokeOnAnimEvent() => OnAnimEvent?.Invoke();
    public void InvokeAnimEndEvent() => AnimEndEvent?.Invoke();
}