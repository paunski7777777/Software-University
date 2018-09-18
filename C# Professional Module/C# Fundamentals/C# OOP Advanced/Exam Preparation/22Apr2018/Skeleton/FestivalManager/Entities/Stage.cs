namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Stage : IStage
    {
        private readonly List<IPerformer> perfomers;
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;

        public Stage()
        {
            this.perfomers = new List<IPerformer>();
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;
        public IReadOnlyCollection<ISong> Songs => this.songs;
        public IReadOnlyCollection<IPerformer> Performers => this.perfomers;

        public void AddPerformer(IPerformer performer)
        {
            this.perfomers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            return this.perfomers.FirstOrDefault(p => p.Name == name);
        }

        public ISet GetSet(string name)
        {
            return this.sets.FirstOrDefault(s => s.Name == name);
        }

        public ISong GetSong(string name)
        {
            return this.songs.FirstOrDefault(s => s.Name == name);
        }

        public bool HasPerformer(string name)
        {
            if (this.perfomers.Any(p => p.Name == name))
            {
                return true;
            }

            return false;
        }

        public bool HasSet(string name)
        {
            if (this.sets.Any(s => s.Name == name))
            {
                return true;
            }

            return false;
        }

        public bool HasSong(string name)
        {
            if (this.songs.Any(s => s.Name == name))
            {
                return true;
            }

            return false;
        }
    }
}
