using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScalers : TweenBase
{

    public override void AnimateObjects()
    {
        if (!playOnStart)
            return;

        PlayAnimation();
    }

    public override void PlayAnimation(Action OnCompleteAction = null)
    {
        foreach (var item in tweens)
        {
            if (item == null)
                continue;

            if (item.target == null)
                continue;

            //Vector3 initScale = item.to;
            //item.target.anchoredPosition = item.from;
            if (item.skipFromInit == false)
                item.target.localScale = item.from;
            if (item == tweens[tweens.Count - 1])
            {
                LTDescr ltDesc = LeanTween.scale(item.target, item.to, ignoreScaleFactor ? item.time : item.time * speedFactor).setFrom(item.from);
                ltDesc.setDelay(ignoreScaleFactor ? item.startDelay : item.startDelay * speedFactor).setEase(item.ltType).setOnComplete(OnCompleteAction);
            }
            else
            {

                LTDescr ltDesc = LeanTween.scale(item.target, item.to, ignoreScaleFactor ? item.time : item.time * speedFactor).setFrom(item.from);
                ltDesc.setDelay(ignoreScaleFactor ? item.startDelay : item.startDelay * speedFactor).setEase(item.ltType);
            }

        }
    }



    public override void ResetAnimation()
    {
        foreach (var item in tweens)
        {
            if (item == null)
                continue;

            if (item.target == null)
                continue;

            item.target.localScale = item.from;

        }
    }


    [ContextMenu("Set To")]
    void Evaluate()
    {
        foreach (var item in tweens)
        {
            if (item == null)
                continue;

            if (item.target == null)
                continue;

            item.to = Vector3.one;
        }
    }
}
