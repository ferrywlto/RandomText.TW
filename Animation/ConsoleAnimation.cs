using System.Threading;

namespace RandomText.tw {
    public abstract class ConsoleAnimation : IConsoleAnimation {
        private Thread _thread;
        protected bool KeepRunning;

        protected abstract Thread GetAnimationThread();

        public void Start() {
            _thread ??= GetAnimationThread();
            KeepRunning = true;
            _thread.Start();
        }

        public void Stop() {
            KeepRunning = false;
            _thread.Join();
        }
    }
}
