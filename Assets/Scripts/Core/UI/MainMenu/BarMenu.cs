using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class BarMenu : MonoBehaviour
    {

        private MainWindow mainWindow;
        private Animator animator;
        private string menuOpenAnimation = "MenuOpen";
        private string menuCloseAnimation = "MenuClose";


        public bool isOpen { get; private set; }

        private void Awake()
        {
            mainWindow = GetComponentInChildren<MainWindow>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T) && isOpen == false)
                Open();

            if (Input.GetKeyDown(KeyCode.T) && isOpen == true)
                Close();
        }

        public void Open()
        {
            isOpen = true;
            animator.Play(menuOpenAnimation);
        }

        public void Close()
        {
            isOpen = false;
            animator.Play(menuCloseAnimation);
        }

    }
}
