using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class MenuSelector : MonoBehaviour
    {
        private MainMenu mainMenu;
        private RectTransform rectTransform;
        private List<RectTransform> selectableOptions = new List<RectTransform>();

        [SerializeField] private AudioSource menuChangeSound;

        public event Action SelectionChanged;

        private int _selectedIndex = 0;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                SelectionChanged?.Invoke();
            }
        }

        public IReadOnlyList<RectTransform> SelectableOptions => selectableOptions;

        private void Awake()
        {
            mainMenu = GetComponentInParent<MainMenu>();
            rectTransform = GetComponent<RectTransform>();

            for (int i = 0; i < rectTransform.parent.childCount; i++)
            {
                if (rectTransform.parent.GetChild(i).CompareTag("Selectable"))
                    selectableOptions.Add(rectTransform.parent.GetChild(i).GetComponent<RectTransform>());
            }
        }

        void Update()
        {
            if (mainMenu.CurrentSelector != this)
                return;

            if (rectTransform.anchoredPosition != selectableOptions[SelectedIndex].anchoredPosition)
                MoveToSelectedOption();
        }

        private void MoveToSelectedOption()
        {
            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, selectableOptions[SelectedIndex].anchoredPosition, 8f);
        }
    }
}