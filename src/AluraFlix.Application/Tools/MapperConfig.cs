using AluraFlix.Application.UseCases.Commands.Categoria;
using AluraFlix.Application.UseCases.Commands.Video;
using AluraFlix.Domain.Entities;
using AutoMapper;

namespace AluraFlix.Application.Tools;
public class MapperConfig : Profile
{
    public MapperConfig()
    {


        RequestPorEntity();
    }

    private void RequestPorEntity()
    {
        CreateMap<AdicionarVideoCommand, Video>();
        CreateMap<AtualizarVideoCommand, Video>();

        CreateMap<CriarCategoriaCommand, Categoria>();
    }
}
