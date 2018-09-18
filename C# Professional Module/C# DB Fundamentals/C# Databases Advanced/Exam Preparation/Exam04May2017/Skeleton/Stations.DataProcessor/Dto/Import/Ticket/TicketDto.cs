using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Import
{
	[XmlType("Ticket")]
	public class TicketDto
	{
		[Required]
		[XmlAttribute("price")]
		[Range(typeof(decimal), "0", "79228162514264337593543950335")]
		public decimal Price { get; set; }

		[Required]
		[XmlAttribute("seat")]
		[RegularExpression(@"^[A-Z]{2}\d{1,6}$")]
		public string Seat { get; set; }

		[Required]
		public Ticket.TripDto Trip { get; set; }

		public Ticket.CardDto Card { get; set; }
	}
}
