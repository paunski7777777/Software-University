using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;
using Stations.Data;
using Stations.DataProcessor.Dto.Import;
using Stations.Models;
using Stations.Models.Enums;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Stations.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportStations(StationsDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			var deserializedStations = JsonConvert.DeserializeObject<StationDto[]>(jsonString);

			var validStations = new List<Station>();
			foreach (var stationDto in deserializedStations)
			{
				if (!IsValid(stationDto))
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				if (stationDto.Town == null)
				{
					stationDto.Town = stationDto.Name;
				}

				var stationAlreadyExists = validStations.Any(s => s.Name == stationDto.Name);
				if (stationAlreadyExists)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var station = Mapper.Map<Station>(stationDto);

				validStations.Add(station);

				sb.AppendLine(string.Format(SuccessMessage, stationDto.Name));
			}

			context.Stations.AddRange(validStations);
			context.SaveChanges();

			var result = sb.ToString();
			return result;
		}

		public static string ImportClasses(StationsDbContext context, string jsonString)
		{
			var deserializedClasses = JsonConvert.DeserializeObject<SeatingClassDto[]>(jsonString);

			var sb = new StringBuilder();

			var validSeatingClasses = new List<SeatingClass>();
			foreach (var seatingClassDto in deserializedClasses)
			{
				if (!IsValid(seatingClassDto))
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var seatingClassAlreadyExists = validSeatingClasses
					.Any(sc => sc.Name == seatingClassDto.Name || sc.Abbreviation == seatingClassDto.Abbreviation);
				if (seatingClassAlreadyExists)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var seatingClass = Mapper.Map<SeatingClass>(seatingClassDto);

				validSeatingClasses.Add(seatingClass);
				sb.AppendLine(string.Format(SuccessMessage, seatingClass.Name));
			}

			context.SeatingClasses.AddRange(validSeatingClasses);
			context.SaveChanges();

			var result = sb.ToString();
			return result;
		}

		public static string ImportTrains(StationsDbContext context, string jsonString)
		{
			var deserializedTrains = JsonConvert.DeserializeObject<TrainDto[]>(jsonString, new JsonSerializerSettings()
			{
				NullValueHandling = NullValueHandling.Ignore
			});

			var sb = new StringBuilder();

			var validTrains = new List<Train>();
			foreach (var trainDto in deserializedTrains)
			{
				if (!IsValid(trainDto))
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var trainAlreadyExists = validTrains.Any(t => t.TrainNumber == trainDto.TrainNumber);
				if (trainAlreadyExists)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var seatsAreValid = trainDto.Seats.All(IsValid);
				if (!seatsAreValid)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var seatingClassesAreValid = trainDto.Seats
					.All(s => context.SeatingClasses.Any(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation));
				if (!seatingClassesAreValid)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var type = Enum.Parse<TrainType>(trainDto.Type);

				var trainSeats = trainDto.Seats.Select(s => new TrainSeat
					{
						SeatingClass =
							context.SeatingClasses.SingleOrDefault(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation),
						Quantity = s.Quantity.Value
					})
					.ToArray();

				var train = new Train
				{
					TrainNumber = trainDto.TrainNumber,
					Type = type,
					TrainSeats = trainSeats
				};

				validTrains.Add(train);

				sb.AppendLine(string.Format(SuccessMessage, trainDto.TrainNumber));
			}

			context.Trains.AddRange(validTrains);
			context.SaveChanges();

			var result = sb.ToString();
			return result;
		}

		public static string ImportTrips(StationsDbContext context, string jsonString)
		{
			var deserializedTrips = JsonConvert.DeserializeObject<TripDto[]>(jsonString, new JsonSerializerSettings()
			{
				NullValueHandling = NullValueHandling.Ignore
			});

			var sb = new StringBuilder();
			var validTrips = new List<Trip>();

			foreach (var tripDto in deserializedTrips)
			{
				if (!IsValid(tripDto))
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var train = context.Trains.SingleOrDefault(t => t.TrainNumber == tripDto.Train);

				var originStation = context.Stations.SingleOrDefault(s => s.Name == tripDto.OriginStation);

				var destinationStation = context.Stations.SingleOrDefault(s => s.Name == tripDto.DestinationStation);

				if (train == null || originStation == null || destinationStation == null)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var departureTime = DateTime.ParseExact(tripDto.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
				var arrivalTime = DateTime.ParseExact(tripDto.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

				TimeSpan timeDifference;
				if (tripDto.TimeDifference != null)
				{
					timeDifference = TimeSpan.ParseExact(tripDto.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture);
				}

				if (departureTime > arrivalTime)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var status = Enum.Parse<TripStatus>(tripDto.Status);

				var trip = new Trip
				{
					Train = train,
					OriginStation = originStation,
					DestinationStation = destinationStation,
					DepartureTime = departureTime,
					ArrivalTime = arrivalTime,
					Status = status,
					TimeDifference = timeDifference
				};

				validTrips.Add(trip);
				sb.AppendLine($"Trip from {tripDto.OriginStation} to {tripDto.DestinationStation} imported.");
			}

			context.Trips.AddRange(validTrips);
			context.SaveChanges();

			var result = sb.ToString();
			return result;
		}

		public static string ImportCards(StationsDbContext context, string xmlString)
		{
			var serializer = new XmlSerializer(typeof(CardDto[]), new XmlRootAttribute("Cards"));
			var deserializedCards = (CardDto[]) serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

			var sb = new StringBuilder();

			var validCards = new List<CustomerCard>();
			foreach (var cardDto in deserializedCards)
			{
				if (!IsValid(cardDto))
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var cardType = Enum.TryParse<CardType>(cardDto.CardType, out var card) ? card : CardType.Normal;

				var customerCard = new CustomerCard
				{
					Name = cardDto.Name,
					Type = cardType,
					Age = cardDto.Age
				};

				validCards.Add(customerCard);
				sb.AppendLine(string.Format(SuccessMessage, customerCard.Name));
			}

			context.Cards.AddRange(validCards);
			context.SaveChanges();

			var result = sb.ToString();
			return result;
		}

		public static string ImportTickets(StationsDbContext context, string xmlString)
		{
			var serializer = new XmlSerializer(typeof(TicketDto[]), new XmlRootAttribute("Tickets"));
			var deserializedTickets = (TicketDto[]) serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

			var sb = new StringBuilder();

			var validTickets = new List<Ticket>();
			foreach (var ticketDto in deserializedTickets)
			{
				if (!IsValid(ticketDto))
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var departureTime =
					DateTime.ParseExact(ticketDto.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

				var trip = context.Trips
					.Include(t => t.OriginStation)
					.Include(t => t.DestinationStation)
					.Include(t => t.Train)
					.ThenInclude(t => t.TrainSeats)
					.SingleOrDefault(t => t.OriginStation.Name == ticketDto.Trip.OriginStation &&
				                                              t.DestinationStation.Name == ticketDto.Trip.DestinationStation &&
				                                              t.DepartureTime == departureTime);
				if (trip == null)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				CustomerCard card = null;
				if (ticketDto.Card != null)
				{
					card = context.Cards.SingleOrDefault(c => c.Name == ticketDto.Card.Name);

					if (card == null)
					{
						sb.AppendLine(FailureMessage);
						continue;
					}
				}

				var seatingClassAbbreviation = ticketDto.Seat.Substring(0, 2);
				var quantity = int.Parse(ticketDto.Seat.Substring(2));

				var seatExists = trip.Train.TrainSeats
					.SingleOrDefault(s => s.SeatingClass.Abbreviation == seatingClassAbbreviation && quantity <= s.Quantity);
				if (seatExists == null)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var seat = ticketDto.Seat;

				var ticket = new Ticket
				{
					Trip = trip,
					CustomerCard = card,
					Price = ticketDto.Price,
					SeatingPlace = seat
				};

				validTickets.Add(ticket);
				sb.AppendLine(string.Format("Ticket from {0} to {1} departing at {2} imported.", 
					trip.OriginStation.Name,
					trip.DestinationStation.Name, 
					trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
			}

			context.Tickets.AddRange(validTickets);
			context.SaveChanges();

			var result = sb.ToString();
			return result;
		}

		private static bool IsValid(object obj)
		{
			var validationContext = new ValidationContext(obj);
			var validationResults = new List<ValidationResult>();

			var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
			return isValid;
		}
	}
}