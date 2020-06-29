using System;
using System.IO;
using System.Threading;

namespace Tasks
{
	public class StreamOutput
	{
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public StreamOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOuput()
        {
            return stringWriter.ToString();
        }

        public void Flush()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}
