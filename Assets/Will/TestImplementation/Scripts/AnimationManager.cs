using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    Animator crochetAnimator;

    void PlayAnimationCrochette(bool _doIt)
    {
        if (!_doIt) return;
        crochetAnimator.SetTrigger("PlayAnimation");
        Debug.Log("in");
    }

    private void Awake()
    {
        GloveInputsManager.OnFifthCombination += PlayAnimationCrochette;
    }
    private void Start()
    {
        if (!crochetAnimator)
            crochetAnimator = gameObject.GetComponent<Animator>();
    }
}