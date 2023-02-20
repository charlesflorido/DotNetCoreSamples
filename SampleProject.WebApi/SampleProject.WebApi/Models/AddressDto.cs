using System;
using SampleProject.UsefulTypes;

namespace SampleProject.WebApi
{
	public class AddressDto
	{
		public Definable<string> AddressLine { get; set; }
		public Definable<string> City { get; set; }
		public Definable<string> State { get; set; }
		public Definable<string> ZipCode { get; set; }
	}
}

