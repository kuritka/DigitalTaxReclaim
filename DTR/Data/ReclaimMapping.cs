using AutoMapper;
using DTR.Data.Entities;
using DTR.ViewModels;

namespace DTR.Data
{
    public class ReclaimMappingProfile : Profile
    {
        public ReclaimMappingProfile()
        {
            CreateMap<Reclaim, AttachTradeDetailViewModel>()
                .ForMember(dest => dest.CreatedBy, opts => opts.MapFrom(src=> src.CreatedBy.Name));
        }
    }
}
