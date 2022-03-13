using UnityEngine;

public class DefeatState : BaseState
{
    [SerializeField] private Animator _animator;

    public override void Begin()
    {
        _animator.SetFloat(AnimatorPaperCharacter.Params.Speed, 0);
    }

    public override void Stop()
    {
    }
}
