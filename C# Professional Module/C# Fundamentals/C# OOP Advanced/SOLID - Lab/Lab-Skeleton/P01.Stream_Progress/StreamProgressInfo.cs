using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamble streamble;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamble streambleResult)
        {
            this.streamble = streambleResult;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamble.BytesSent * 100) / this.streamble.Length;
        }
    }
}
