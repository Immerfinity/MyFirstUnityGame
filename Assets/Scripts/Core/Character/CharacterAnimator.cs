using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
namespace Core
{
    public class CharacterAnimator
    {
        private Character character;
        private Animator animator;

        private string WalkingParameter = "isWalking";
        private string HorizotalParameter = "xDir";
        private string VerticalParameter = "yDir";

        public CharacterAnimator(Character character)
        {
            this.character = character;
            this.animator = character.GetComponent<Animator>();
        }

        public void ChooseLayer()
        {
            bool isWalking = character.IsMoving;
            animator.SetBool(WalkingParameter, isWalking);
        }

        public void UpdateParameters()
        {
            animator.SetFloat(HorizotalParameter, character.Facing.x);
            animator.SetFloat(VerticalParameter, character.Facing.y);
        }
    }
}
