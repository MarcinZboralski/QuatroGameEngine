using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;

namespace QuatroGameEngine.Input
{
    public static class InputSystem
    {
        public static List<Button> Buttons = new List<Button>();


        public static bool GetAnyKey()
        {
            return Keyboard.GetState().IsAnyKeyDown;
        }

        public static bool GetKeyDown(Key keyCode)
        {
            return Keyboard.GetState().IsKeyDown(keyCode);
        }

        public static bool GetKeyUp(Key keyCode)
        {
            return Keyboard.GetState().IsKeyUp(keyCode);
        }

        public static bool GetButtonDown(string buttonName)
        {
            bool isPressed = false;

            foreach (var button in Buttons)
            {
                if (button.buttonName == buttonName)
                {
                    isPressed = GetKeyDown(button.firstKey) || GetKeyDown(button.secondKey);
                   break;
                }
            }

            return isPressed;
        }

        public static bool GetButtonUp(string buttonName)
        {
            bool isPressed = false;

            foreach (var button in Buttons)
            {
                if (button.buttonName == buttonName)
                {
                    isPressed = GetKeyUp(button.firstKey) || GetKeyUp(button.secondKey);
                    break;
                }
            }

            return isPressed;
        }
    }
}
