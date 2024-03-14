using AutoMapper;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Application.AutoMappings
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<UsuarioModel, Usuario>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UsuarioResultModel, Usuario>()
                .ReverseMap();

            CreateMap<PaisModel, Pais>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PaisResultModel, Pais>()
                .ReverseMap();

            CreateMap<EstadoModel, Estado>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<EstadoResultModel, Estado>()
                .ReverseMap();

            CreateMap<CidadeModel, Cidade>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CidadeResultModel, Cidade>()
                .ReverseMap();

            CreateMap<EmpresaModel, Empresa>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<EmpresaResultModel, Empresa>()
                .ReverseMap();

        }
    }
}
