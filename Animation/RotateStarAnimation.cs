using System;
using System.Threading;

namespace RandomText.tw {
    public class RotateStarAnimation : ConsoleAnimation {
        private int _counter;
        private int _rotateSpeed = 100;
        protected override Thread GetAnimationThread() => new(
            () => {
                while (KeepRunning) {
                    switch (_counter % 4) {
                        case 0: Console.Write("|"); break;
                        case 1: Console.Write("/"); break;
                        case 2: Console.Write("-"); break;
                        case 3: Console.Write("\\"); break;
                    }
                    Thread.Sleep(_rotateSpeed);
                    if(Console.CursorLeft == 1)
                        Console.SetCursorPosition(Console.CursorLeft -1, Console.CursorTop);

                    _counter+=1;
                    if (_counter >= 1000) _counter = 0;
                }
                Console.WriteLine();
            });

        public void SetRotateSpeed(int speed) {
            if (speed is > 100 or < 1) throw new ArgumentException("speed should between 1 and 100 inclusive.");
            _rotateSpeed = (int)Math.Ceiling(1000m / speed);
        }
    }
}
