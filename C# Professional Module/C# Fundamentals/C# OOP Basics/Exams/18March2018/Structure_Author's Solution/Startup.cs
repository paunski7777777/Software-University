using DungeonsAndCodeWizards.Core;
using DungeonsAndCodeWizards.Core.IO;
using DungeonsAndCodeWizards.Core.IO.Contracts;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			IReader reader = new ConsoleReader();
			IWriter writer = new ConsoleWriter();

			var engine = new Engine(reader, writer);
			engine.Run();
		}
	}
}