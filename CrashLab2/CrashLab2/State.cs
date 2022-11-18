namespace CrashLab2
{
    using System;

    internal class State
    {
        public int _iterations = 1000;
        public int _size = 1024;

        public State(int size, int iterations)
        {
            this._size = size;
            this._iterations = iterations;
        }
    }
}

