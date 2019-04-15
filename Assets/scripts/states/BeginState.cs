using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Code.Interfaces;

namespace Assets.Code.States
{

    public class BeginState : IStateBase
    {
        private StateManager manager;



        public BeginState(StateManager managerRef)
        {
            manager = managerRef;
            

        }

        public void StateUpdate()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                manager.SwitchState(new PlayState(manager));

            }





        }
        public void ShowIt()
        {
            if (GUI.Button(new Rect(10, 10, 150, 100), "Press to Play"))
            {
                manager.SwitchState(new PlayState(manager));
                if (Application.loadedLevelName != "Level")
                {
                    Application.LoadLevel("Level");
                }
            }

        }

    }




}


