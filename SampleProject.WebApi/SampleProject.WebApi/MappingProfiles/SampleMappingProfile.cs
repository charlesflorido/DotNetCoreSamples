using System;
using AutoMapper;
using SampleProject.Database;
using SampleProject.UsefulTypes;

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
				.ForMember(d => d.DateOfBirth, o => o.MapFrom(s => s.DateOfBirth))
				.ForAllMembers( o => o.Condition((src, dest, srcMember, destMember, context) =>
				{
					var type = srcMember.GetType();
					var isGenericType = srcMember.GetType().IsGenericType;
					var canConvert = srcMember is IDefinable;

					if(isGenericType)
					{
						var typeDef = srcMember.GetType().GetGenericTypeDefinition();
					}
					return (srcMember.GetType().IsGenericType && srcMember.GetType().GetGenericTypeDefinition() == typeof(Definable<>)) ? ((IDefinable)srcMember).IsDefined : true;
				}
				));
		}
	}
}

