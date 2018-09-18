using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Export
{
	[XmlType("Card")]
    public class CardDto
    {
		[XmlAttribute("name")]
	    public string Name { get; set; }

		[XmlAttribute("type")]
	    public string Type { get; set; }

	    public Export.TicketDto[] Tickets { get; set; }
    }
}
