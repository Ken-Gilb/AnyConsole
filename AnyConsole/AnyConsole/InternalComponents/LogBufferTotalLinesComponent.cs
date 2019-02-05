﻿namespace AnyConsole.InternalComponents
{
    public class LogBufferTotalLinesComponent : BaseProcessComponent
    {
        private int _currentLogLine;
        private int _totalLogLines;
        private bool _isPaused;

        public LogBufferTotalLinesComponent(ConsoleDataContext consoleDataContext) : base(consoleDataContext)
        {
        }

        public override string Render(object parameters)
        {
            try
            {
                return $"Total: {_totalLogLines}";
            }
            finally
            {
                HasUpdates = false;
            }
        }

        public override void Tick(ulong tickCount)
        {
            base.Tick(tickCount);

            var extendedConsole = _consoleDataContext.GetData<ExtendedConsole>("ExtendedConsole");
            var totalLogLines = extendedConsole._fullLogHistory.Count;

            if(_totalLogLines != totalLogLines)
            {
                _totalLogLines = totalLogLines;
                HasUpdates = true;
            }
        }
    }
}
