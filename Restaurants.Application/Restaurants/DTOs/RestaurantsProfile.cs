using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.DTOs;

public class RestaurantsProfile : Profile
{
    public RestaurantsProfile()
    {
        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(d => d.Address, opt => 
                opt.MapFrom(src => new Address
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode
                }));

        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(d => d.City, o => 
                o.MapFrom(s => s.Address == null ? null : s.Address.City))
            .ForMember(d => d.Street, o => 
                o.MapFrom(s => s.Address == null ? null : s.Address.Street))
            .ForMember(d => d.PostalCode, o => 
                o.MapFrom(s => s.Address == null ? null : s.Address.PostalCode))
            .ForMember(d => d.Dishes, o => 
                o.MapFrom(s => s.Dishes));
    }
}   

