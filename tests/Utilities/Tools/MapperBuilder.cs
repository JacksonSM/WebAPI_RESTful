using AluraFlix.Application.Tools;
using AutoMapper;

namespace Utilities.Tools;
public class MapperBuilder
{
    public static IMapper Instance()
    {

        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MapperConfig());
        });
        return mockMapper.CreateMapper();
    }
}