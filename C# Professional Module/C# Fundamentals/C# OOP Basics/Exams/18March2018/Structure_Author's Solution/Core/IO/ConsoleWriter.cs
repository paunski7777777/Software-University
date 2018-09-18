using System;
using DungeonsAndCodeWizards.Core.IO.Contracts;

namespace DungeonsAndCodeWizards.Core.IO
{
	public class ConsoleWriter : IWriter
	{
		public void WriteLine(string message)
		{
			Console.WriteLine(message);
		}
	}
}