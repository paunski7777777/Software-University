namespace SIS.Http.Sessions
{
    using SIS.Http.Sessions.Contracts;

    using System.Collections.Generic;

    public class HttpSession : IHttpSession
    {
        private readonly Dictionary<string, object> sessionParameters;

        public string Id { get; }

        public HttpSession(string id)
        {
            this.Id = id;
            this.sessionParameters = new Dictionary<string, object>();
        }

        public void AddParameter(string name, object parameter)
        {
            this.sessionParameters.Add(name, parameter);
        }

        public void ClearParameters()
        {
            this.sessionParameters.Clear();
        }

        public bool ContainsParameter(string name)
        {
            return this.sessionParameters.ContainsKey(name);
        }

        public object GetParameter(string name)
        {
            return this.sessionParameters.GetValueOrDefault(name, null);
        }
    }
}