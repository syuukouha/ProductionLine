using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MachineController : MonoBehaviour
{
    public Hand HandLeft;
    public Hand HandRight;

    public Interactable StartButton;
    public Interactable LeftOnlyButton;
    public Interactable MiddleOnlyButton;
    public Interactable RightOnlyButton;
    public Interactable FullButton;
    public Interactable SwitchPanelButton;
    public Interactable PauseButton;

    private Animator animator;
    private SteamVR_Action_Boolean TrigerAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
    private bool isPause = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HintController();
        if (!animator.GetBool("Start"))
        {
            if (TrigerAction.GetStateDown(SteamVR_Input_Sources.Any))
            {
                if (StartButton.isHovering)
                {
                    animator.SetBool("Start", true);
                }
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Start"))
            return;

        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Reset"))
        {
            if (TrigerAction.GetStateDown(SteamVR_Input_Sources.Any))
            {
                if (PauseButton.isHovering)
                {
                    isPause = !isPause;
                    animator.speed = isPause ? 0.0f : 1.0f;
                }
                if (LeftOnlyButton.isHovering)
                {
                    animator.SetTrigger("LeftOnly");
                }
                if (MiddleOnlyButton.isHovering)
                {
                    animator.SetTrigger("MiddleOnly");
                }
                if (RightOnlyButton.isHovering)
                {
                    animator.SetTrigger("RightOnly");
                }
                if (FullButton.isHovering)
                {
                    animator.SetTrigger("Full");
                }
                if (SwitchPanelButton.isHovering)
                {
                    animator.SetTrigger("SwitchPanel");
                }
            }
        }
        else
        {
            if (TrigerAction.GetStateDown(SteamVR_Input_Sources.Any))
            {
                if (PauseButton.isHovering)
                {
                    isPause = !isPause;
                    animator.speed = isPause ? 0.0f : 1.0f;
                }
            }
        }
    }

    void HintController()
    {
        if (StartButton.isHovering)
        {
            ControllerButtonHints.ShowTextHint(StartButton.hoveringHand, TrigerAction, "启动");
        }

        if (LeftOnlyButton.isHovering)
        {
            ControllerButtonHints.ShowTextHint(LeftOnlyButton.hoveringHand, TrigerAction, "操作Ⅰ");
        }

        if (MiddleOnlyButton.isHovering)
        {
            ControllerButtonHints.ShowTextHint(MiddleOnlyButton.hoveringHand, TrigerAction, "操作Ⅱ");
        }

        if (RightOnlyButton.isHovering)
        {
            ControllerButtonHints.ShowTextHint(RightOnlyButton.hoveringHand, TrigerAction, "操作Ⅲ");
        }

        if (FullButton.isHovering)
        {
            ControllerButtonHints.ShowTextHint(FullButton.hoveringHand, TrigerAction, "完整操作");
        }

        if (SwitchPanelButton.isHovering)
        {
            ControllerButtonHints.ShowTextHint(SwitchPanelButton.hoveringHand, TrigerAction, "换盘");
        }

        if (PauseButton.isHovering)
        {
            ControllerButtonHints.ShowTextHint(PauseButton.hoveringHand, TrigerAction, isPause ? "恢复" : "暂停");
        }

        if (!StartButton.isHovering && !LeftOnlyButton.isHovering && !MiddleOnlyButton.isHovering
            && !RightOnlyButton.isHovering && !FullButton.isHovering && !SwitchPanelButton.isHovering && !PauseButton.isHovering)
        {
            ControllerButtonHints.HideAllTextHints(HandLeft);
            ControllerButtonHints.HideAllTextHints(HandRight);
        }
    }


}
