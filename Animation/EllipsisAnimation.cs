using System;
using System.Threading;

namespace RandomText.tw {
    public class EllipsisAnimation : ConsoleAnimation {
        private int _speed = 100;
        private int counter;
        protected override Thread GetAnimationThread() => new(
            () => {
                while (KeepRunning) {
                    Console.Write("...");
                    Thread.Sleep(_speed);
                    counter += 1;

                    if (counter < 10) continue;

                    counter = 0;
                    Console.SetCursorPosition(Console.CursorLeft - 30, Console.CursorTop);
                    Console.Write("".PadRight(30));
                    Console.SetCursorPosition(Console.CursorLeft - 30, Console.CursorTop);
                }

                counter = 0;
            });

        public void SetSpeed(int speed) {
            if (speed is > 100 or < 1) throw new ArgumentException("speed should between 1 and 100 inclusive.");
            _speed = (int)Math.Ceiling(1000m / speed);
        }
    }
}
