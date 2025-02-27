using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]

    public abstract class Character : MonoBehaviour
    {
        public CharacterMover Movement { get; private set; }
        public CharacterTurner Turner { get; private set; }
        public CharacterAnimator Animator { get; private set; }
        public bool IsMoving => Movement.IsMoving;
        public Vector2Int Facing => Turner.Facing;
        public Vector2Int CurrentCell => Game.World.Map.Grid.GetCell2D(this.gameObject);
        public Map Map=> Game.World.Map;

        protected virtual void Awake()
        {
            Movement = new CharacterMover(this);
            Turner = new CharacterTurner(this);
            Animator = new CharacterAnimator(this);
        }

        protected virtual void Start()
        {
            transform.position = Game.World.Map.Grid.GetCellCenter2D(CurrentCell);
            Game.World.Map.OccupiedCells.Add(CurrentCell, this);
        }

        protected virtual void Update()
        {
            Animator.ChooseLayer();
            Animator.UpdateParameters();
        }
    }
}