using System;
using System.Threading;

namespace Console_Tetris
{
    public class InputThread
    {
        public static InputThread Instance => new InputThread();

        public event Action InputEvent;

        private InputThread()
        {
            Thread inputThread = new Thread(CheckInput)
            {
                IsBackground = true
            };
            inputThread.Start();
        }

        private void CheckInput()
        {
            while (true)
            {
                InputEvent?.Invoke();
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}