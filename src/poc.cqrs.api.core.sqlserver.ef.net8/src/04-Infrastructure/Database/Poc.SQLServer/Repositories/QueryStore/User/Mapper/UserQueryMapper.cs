using Poc.Contract.Query.User.EF.QueriesModel;
using Poc.Domain.Entities.User;

namespace Poc.SQLServer.Repositories.QueryStore.User.Mapper;

public static class UserQueryMapper
{
    public static List<UserQueryModel> MapEntityToModel(List<UserEntity> entities)
    {
        var models = new List<UserQueryModel>();

        foreach (var entity in entities)
        {
            var model = new UserQueryModel
            {
                FirstName = entity.FirstName,
                Email = entity.Email.Address,
            };
            models.Add(model);
        }

        return models;
    }
}
