using System;
using SampleProject.UsefulTypes;

namespace SampleProject.WebApi
{
	public class UserDto
	{
		public Definable<string> FirstName { get; set; }
		public Definable<string> LastName { get; set; }
		public Definable<string> Email { get; set; }
		public Definable<AddressDto> Address { get; set; }
		public Definable<DateTime?> DateOfBirth { get; set; }
	}
}

