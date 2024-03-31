using AutoMapper;
using DomainLayer.Models;
using MarketPlaceProject.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Item, ItemDTO>();
       
    }
}
