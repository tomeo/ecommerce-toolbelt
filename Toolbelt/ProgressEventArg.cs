using System;

namespace Toolbelt
{
    public class ProgressEventArg : EventArgs
    {
        public ProgressEventArg(int percentage, string status, string log, string imagePath)
        {
            Percentage = percentage;
            Status = status;
            Log = log;
            ImagePath = imagePath;
        }
        public int Percentage { get; private set; }
        public string Status { get; private set; }
        public string Log { get; private set; }
        public string ImagePath { get; private set; }
    }
}