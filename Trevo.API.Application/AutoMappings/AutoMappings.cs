﻿using AutoMapper;
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

            CreateMap<MarcaModel, Marca>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<MarcaResultModel, Marca>()
                .ReverseMap();

            CreateMap<ModeloModel, Modelo>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ModeloResultModel, Modelo>()
                .ReverseMap();

            CreateMap<TipoDespesaModel, TipoDespesa>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<TipoDespesaResultModel, TipoDespesa>()
                .ReverseMap();

            CreateMap<CategoriaDespesaModel, CategoriaDespesa>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CategoriaDespesaResultModel, CategoriaDespesa>()
                .ReverseMap();

            CreateMap<CategoriaVeiculoModel, CategoriaVeiculo>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CategoriaVeiculoResultModel, CategoriaVeiculo>()
                .ReverseMap();

            CreateMap<CombustivelModel, Combustivel>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CombustivelResultModel, Combustivel>()
                .ReverseMap();

            CreateMap<CambioModel, Cambio>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CambioResultModel, Cambio>()
                .ReverseMap();

            CreateMap<CorModel, Cor>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CorResultModel, Cor>()
                .ReverseMap();

            CreateMap<AcessorioModel, Acessorio>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<AcessorioResultModel, Acessorio>()
                .ReverseMap();

            CreateMap<SituacaoVeiculoModel, SituacaoVeiculo>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<SituacaoVeiculoResultModel, SituacaoVeiculo>()
                .ReverseMap();

            CreateMap<FormaPagamentoModel, FormaPagamento>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<FormaPagamentoResultModel, FormaPagamento>()
                .ReverseMap();

            CreateMap<FornecedorModel, Fornecedor>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<FornecedorResultModel, Fornecedor>()
                .ReverseMap();

            CreateMap<VendedorModel, Vendedor>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<VendedorResultModel, Vendedor>()
                .ReverseMap();

            CreateMap<FinanceiraModel, Financeira>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<FinanceiraResultModel, Financeira>()
                .ReverseMap();

            CreateMap<VersaoModel, Versao>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<VersaoResultModel, Versao>()
                .ReverseMap();

            CreateMap<ClienteModel, Cliente>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ClienteResultModel, Cliente>()
                .ReverseMap();

            CreateMap<ModeloDesejadoModel, ModeloDesejado>()
                .ForMember(dest => dest.CriadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoPor, opt => opt.Ignore())
                .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
