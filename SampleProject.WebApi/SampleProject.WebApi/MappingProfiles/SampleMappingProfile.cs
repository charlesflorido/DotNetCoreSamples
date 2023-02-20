using System;
using AutoMapper;
using SampleProject.Database;

namespace SampleProject.WebApi
{
	public class SampleMappingProfile : Profile
	{
		public SampleMappingProfile()
		{
			CreateMap<UserDto, User>()
				.ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName))
				.ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName))
				.ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
				.ForMember(d => d.AddressLine, o => o.MapFrom(s => s.Address.AddressLine))
				.ForMember(d => d.City, o => o.MapFrom(s => s.Address.City))
				.ForMember(d => d.State, o => o.MapFrom(s => s.Address.State))
				.ForMember(d => d.Zip, o => o.MapFrom(s => s.Address.ZipCode));
		}
	}
}

