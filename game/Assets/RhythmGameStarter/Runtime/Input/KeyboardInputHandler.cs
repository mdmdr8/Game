﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RhythmGameStarter
{
    [HelpURL("https://bennykok.gitbook.io/rhythm-game-starter/hierarchy-overview/input")]
    public class KeyboardInputHandler : BaseInputHandler
    {
        [Title("Track Action Key", 3)]
        [ReorderableDisplay("Track")]
        public StringList keyMapping;

        [Title("Swipe Action Key", 3)]
        public KeyCode up;
        public KeyCode down;
        public KeyCode left;
        public KeyCode right;

        public List<bool> isPressed;

        [System.Serializable]
        public class StringList : ReorderableList<string> { }

        public override bool GetTrackActionKeyDown(Track track, int index)
        {
            var key = keyMapping[index];
            return isPressed[index] || Input.GetKeyDown(key);
        }

        public override bool GetTrackActionKeyUp(Track track, int index)
        {
            var key = keyMapping[index];
            return !isPressed[index] || Input.GetKeyDown(key);
        }

        public override bool GetTrackActionKey(Track track, int index)
        {
            var key = keyMapping[index];
            return isPressed[index] || Input.GetKeyDown(key);
        }

        public void KeyDown(int index)
        {
            isPressed[index] = true;
        }

        public void KeyUp(int index)
        {
            isPressed[index] = false;
        }

        public void KeyToggle(int index)
        {
            isPressed[index] = !isPressed[index];
        }

        public override bool GetTrackDirectionKey(Note.SwipeDirection swipeDirection)
        {
            KeyCode key = KeyCode.None;
            switch (swipeDirection)
            {
                case Note.SwipeDirection.Up:
                    key = up;
                    break;
                case Note.SwipeDirection.Down:
                    key = down;
                    break;
                case Note.SwipeDirection.Left:
                    key = left;
                    break;
                case Note.SwipeDirection.Right:
                    key = right;
                    break;
            }
            return Input.GetKey(key);
        }

    }
}