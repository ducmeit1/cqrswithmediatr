using AutoMapper;
using Customer.Domain.Dtos;

namespace Customer.Service.Dxos
{
    public class CustomerDxos : ICustomerDxos
    {
        private readonly IMapper _mapper;

        public CustomerDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.Models.Customer, Domain.Dtos.CustomerDto>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dst => dst.Age, opt => opt.MapFrom(src => src.Age))
                    .ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Address))
                    .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                    .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email));
            });

            _mapper = config.CreateMapper();
        }
        
        public CustomerDto MapCustomerDto(Domain.Models.Customer customer)
        {
            return _mapper.Map<Domain.Models.Customer, Domain.Dtos.CustomerDto>(customer);
        }
    }
}