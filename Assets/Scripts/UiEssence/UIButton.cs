using System.Collections.Generic;
using CommandsEssence;
using UnityEngine;

namespace UiEssence
{
    public class UIButton : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button _button;

        private List<ICommand> _commands;

        private void Awake()
        {
            _button.onClick.AddListener(() => _commands.ForEach(command => command.Perform()));
        }

        public void AddCommand(ICommand command)
        {
            _commands ??= new List<ICommand>();
            _commands.Add(command);
        }
    }
}