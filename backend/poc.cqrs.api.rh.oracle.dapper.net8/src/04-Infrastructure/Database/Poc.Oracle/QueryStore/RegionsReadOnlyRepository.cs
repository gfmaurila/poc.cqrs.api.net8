using AutoMapper;
using Dapper;
using poc.core.api.net8.Filter.QueryStore;
using poc.core.api.net8.Filter.QueryStore.Response;
using Poc.Contract.Query.Region.Interfaces;
using Poc.Contract.Query.Region.ViewModels;
using Poc.Domain.Entities.Region;
using Poc.Oracle.Context;
using Poc.Oracle.SQL;
using System.Data;

namespace Poc.Oracle.QueryStore;

public class RegionsReadOnlyRepository : IRegionsReadOnlyRepository
{
    private readonly OracleDbContext _dbContext;
    private readonly IMapper _mapper;

    public RegionsReadOnlyRepository(OracleDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<RegionQueryModel> Get(decimal id)
    {
        using IDbConnection dbConnection = _dbContext.CreateConnection();
        dbConnection.Open();

        var result = await dbConnection.QueryFirstOrDefaultAsync<RegionEntity>(
            RegionSqlConsts.SQL_GET_BY_ID,
            new { PR_REGION_ID = id }
        );

        var mapper = _mapper.Map<RegionQueryModel>(result);
        return mapper;
    }

    public async Task<List<RegionQueryModel>> Get()
    {
        using IDbConnection dbConnection = _dbContext.CreateConnection();
        dbConnection.Open();
        var result = await dbConnection.QueryAsync<RegionEntity>(RegionSqlConsts.SQL_GET);
        var mapper = _mapper.Map<List<RegionQueryModel>>(result);
        return mapper.AsList();
    }

    public async Task<PaginationResponse<RegionQueryModel>> Get(uint page, uint itemsPerPage, string name)
    {
        using IDbConnection dbConnection = _dbContext.CreateConnection();
        dbConnection.Open();

        var filters = new Dictionary<string, object>();
        var param = new DynamicParameters();
        var query = RegionSqlConsts.SQL_GET;
        var countQuery = RegionSqlConsts.SQL_COUNT;

        // Construir a consulta dinamicamente com filtros
        OracleDynamicParametersFilters.QueryBuilderAsync(param, "RegionName", name, ref query);
        OracleDynamicParametersFilters.QueryBuilderAsync(param, "RegionName", name, ref countQuery);

        // Obter o número total de itens
        var totalItems = await dbConnection.ExecuteScalarAsync<uint>(countQuery, param);

        // Adicionar paginação à consulta
        var (adjustedPage, adjustedItemsPerPage) = OracleDynamicParametersFilters.AddPaginacaoAsync(ref query, page, itemsPerPage);

        // Obter os itens paginados
        var result = (await dbConnection.QueryAsync<RegionEntity>(query, param)).ToList();

        var mapper = _mapper.Map<List<RegionQueryModel>>(result);

        return new PaginationResponse<RegionQueryModel>(adjustedPage, adjustedItemsPerPage, totalItems, mapper, filters);
    }
}
