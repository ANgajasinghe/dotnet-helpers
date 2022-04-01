using AutoMapper;

namespace Vertex.RMS.Application.Common.Mappings;

public interface IMapTo<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(GetType(), typeof(T));
    }
}