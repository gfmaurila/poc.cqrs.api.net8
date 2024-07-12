using AutoMapper;
using Poc.Contract.Command.User.Request;
using Poc.Contract.Query.User.EF.QueriesModel;
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
    }
}
