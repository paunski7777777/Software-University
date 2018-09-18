using LoggerApp.Models.Contracts;
using System;

namespace LoggerApp.Models.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout = null;

            switch (type)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;

                case "XmlLayout":
                    layout = new XmlLayout();
                    break;

                default:
                    throw new ArgumentException("Invalid layout type!");
            }

            return layout;
        }
    }
}
