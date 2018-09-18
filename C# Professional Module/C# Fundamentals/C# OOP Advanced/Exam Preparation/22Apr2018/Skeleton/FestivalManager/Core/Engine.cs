namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private const string End = "END";

        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalController, ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
        }

        public void Run()
        {
            string input = this.reader.ReadLine();

            while (!input.Equals(End))
            {
                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }

                input = reader.ReadLine();
            }

            this.writer.WriteLine("Results:");
            string report = this.festivalCоntroller.ProduceReport();       
            this.writer.WriteLine(report.Trim());
        }

        public string ProcessCommand(string input)
        {
            string[] tokens = input.Split();
            string command = tokens[0];

            string result = string.Empty;

            if (command == "RegisterSet")
            {
                result = this.festivalCоntroller.RegisterSet(tokens);
            }
            else if (command == "SignUpPerformer")
            {
                result = this.festivalCоntroller.SignUpPerformer(tokens);
            }
            else if (command == "RegisterSong")
            {
                result = this.festivalCоntroller.RegisterSong(tokens);
            }
            else if (command == "AddSongToSet")
            {
                result = this.festivalCоntroller.AddSongToSet(tokens);
            }
            else if (command == "AddPerformerToSet")
            {
                result = this.festivalCоntroller.AddPerformerToSet(tokens);
            }
            else if (command == "RepairInstruments")
            {
                result = this.festivalCоntroller.RepairInstruments(null);
            }
            else if (command == "LetsRock")
            {
                result = this.setCоntroller.PerformSets();
            }

            return result;
        }
    }
}