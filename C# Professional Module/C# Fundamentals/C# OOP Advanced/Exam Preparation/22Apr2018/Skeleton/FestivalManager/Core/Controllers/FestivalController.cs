namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Linq;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string RegisteredSet = "Registered {0} set";
        private const string RegisteredPerformer = "Registered performer {0}";
        private const string RegisteredSong = "Registered song {0} ({1:mm\\:ss})";
        private const string InvalidSet = "Invalid set provided";
        private const string InvalidSong = "Invalid song provided";
        private const string AddedSong = "Added {0} ({1:mm\\:ss}) to {2}";
        private const string InvalidPerfomer = "Invalid performer provided";
        private const string AddedPerfomer = "Added {0} to {1}";
        private const string RepairedInstrument = "Repaired {0} instruments";

        private const string TimeFormat = @"mm\:ss";

        private IStage stage;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISetFactory setFactory;
        private ISongFactory songFactory;

        public FestivalController(IStage stage, IInstrumentFactory instrumentFactory, IPerformerFactory performerFactory,
            ISetFactory setFactory, ISongFactory songFactory)
        {
            this.stage = stage;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.setFactory = setFactory;
            this.songFactory = songFactory;
        }

        public string ProduceReport()
        {
            string result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            var minutes = TimeSpan.FromMinutes(totalFestivalLength.TotalMinutes);
            var format = string.Format($"{(int)minutes.TotalMinutes:00}:{minutes.Seconds.ToString("D2")}");

            result += ($"Festival length: {format}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                var minutes2 = TimeSpan.FromMinutes(set.ActualDuration.TotalMinutes);
                var format2 = string.Format($"{(int)minutes2.TotalMinutes:00}:{minutes2.Seconds.ToString("D2")}");

                result += ($"--{set.Name} ({format2}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString();
        }

        public string RegisterSet(string[] args)
        {
            string name = args[1];
            string type = args[2];

            ISet set = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            return string.Format(RegisteredSet, type);
        }

        public string SignUpPerformer(string[] args)
        {
            string name = args[1];
            int age = int.Parse(args[2]);
            string[] instrumentArgs = args.Skip(3).ToArray();

            var instruments = instrumentArgs
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            IPerformer performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return string.Format(RegisteredPerformer, performer.Name);
        }

        public string RegisterSong(string[] args)
        {
            string name = args[1];
            TimeSpan duration = TimeSpan.ParseExact(args[2], TimeFormat, null);

            ISong song = this.songFactory.CreateSong(name, duration);
            this.stage.AddSong(song);

            return string.Format(RegisteredSong, song.Name, song.Duration);
        }

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[1];
            string setName = args[2];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException(InvalidPerfomer);
            }
            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(InvalidSet);
            }

            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return string.Format(AddedPerfomer, performer.Name, set.Name);
        }

        public string RepairInstruments(string[] args)
        {
            var instruments = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instruments)
            {
                instrument.Repair();
            }

            return string.Format(RepairedInstrument, instruments.Length);
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[1];
            string setName = args[2];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(InvalidSet);
            }
            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException(InvalidSong);
            }

            ISet set = this.stage.GetSet(setName);
            ISong song = this.stage.GetSong(songName);

            set.AddSong(song);

            return string.Format(AddedSong, song.Name, song.Duration, set.Name);
        }
    }
}