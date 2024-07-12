using AutoMapper;
using Poc.Contract.Query.Post.QueriesModel;
using Poc.Domain.Entities.Post;

namespace Poc.Contract.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region MySQL
        CreateMap<PostEntity, PostQueryModel>();
        CreateMap<PostQueryModel, PostEntity>();
        #endregion
    }
}
