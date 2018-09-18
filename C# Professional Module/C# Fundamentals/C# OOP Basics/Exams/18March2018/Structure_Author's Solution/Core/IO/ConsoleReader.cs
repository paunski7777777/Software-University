using System;
using DungeonsAndCodeWizards.Core.IO.Contracts;

namespace DungeonsAndCodeWizards.Core.IO
{
	public class ConsoleReader : IReader
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}
	}
}
