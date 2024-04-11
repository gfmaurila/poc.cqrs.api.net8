using AutoMapper;
using Poc.Contract.Command.Core.User.Request;
using Poc.Contract.Query.HR.Region.ViewModels;
using Poc.Contract.Query.MKT.Post.QueriesModel;
using Poc.Contract.Query.User.EF.QueriesModel;
using Poc.Domain.Entities.HR.Region;
using Poc.Domain.Entities.MKT.Post;
using Poc.Domain.Entities.User;
using Poc.Domain.Entities.User.DTO;

namespace Poc.Contract.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region SqlServer
        CreateMap<UserEntity, UserQueryModel>();
        CreateMap<UserQueryModel, UserEntity>();

        CreateMap<UpdateUserCommand, UpdateUserDTO>();
        CreateMap<UpdateUserDTO, UpdateUserCommand>();
        #endregion

        #region Oracle
        CreateMap<RegionEntity, RegionQueryModel>();
        CreateMap<RegionQueryModel, RegionEntity>();
        #endregion

        #region MySQL
        CreateMap<PostEntity, PostQueryModel>();
        CreateMap<PostQueryModel, PostEntity>();
        #endregion
    }
}
