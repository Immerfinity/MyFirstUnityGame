using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class CommandFetcher
    {
        public static CommandFetcher CurrentFetcher;


        private BattleControl battleControl;
        private TargetSystem targetSystem;
        private Ally ally;
        private CommandMenu commandMenu;

        public IBattleCommand Command { get; private set; }

        public CommandFetcher(Ally ally)
        {
            this.ally = ally;
            battleControl = GameObject.FindObjectOfType<BattleControl>();
            targetSystem = battleControl.GetComponentInChildren<TargetSystem>();
            commandMenu = GameObject.FindObjectOfType<CommandMenu>();

            CurrentFetcher = this;
        }

        public IEnumerator Co_GetCommand()
        {
            commandMenu.Activate();

            while (commandMenu.SelectedCommand is null)
            {
                /*TEST CODE
                if (Input.GetKeyDown(KeyCode.A))
                {
                    targetSystem.GetTarget(TargetType.AnySingle, TargetDefault.Enemy);

                    while (targetSystem.IsFindingTarget)
                        yield return null;

                    Actor target = targetSystem.SelectedTargets[0];
                    Command = new Attack(ally, target);
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    Command = new RunAway(ally);
                }
                TEST CODE*/
                yield return null;
            }

            commandMenu.Deactivate();

            switch (commandMenu.SelectedCommand)
            {
                case (BattleCommand.Attack):
                    targetSystem.GetTarget(TargetType.AnySingle, TargetDefault.Enemy);

                    while (targetSystem.IsFindingTarget)
                        yield return null;

                    Actor target = targetSystem.SelectedTargets[0];
                    Command = new Attack(ally, target);
                    break;

                case (BattleCommand.Run):
                    Command = new RunAway(ally);
                    break;

                case (BattleCommand.Item):
                    targetSystem.GetTarget(TargetType.AnySingle, TargetDefault.Ally);

                    while (targetSystem.IsFindingTarget)
                        yield return null;

                    target = targetSystem.SelectedTargets[0];
                    Command = new Heal(ally, target);
                    break;
            }
        }

        public void SetCommand(IBattleCommand command)
        {
            Command = command;
        }
    }
}
