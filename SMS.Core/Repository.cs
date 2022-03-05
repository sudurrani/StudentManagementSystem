using Dapper;
using Microsoft.Extensions.Configuration;
using SMS.Application.Shared.Common.DTOs;
using SMS.Application.Shared.Common.Interfaces;
using SMS.Core.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core
{
    public class Repository : IRepository
    {
        private readonly IConfiguration configuration;
        ResponseOutputDto _responseOutputDto;

        public Repository(IConfiguration _Configuration)
        {
            configuration = _Configuration;
            _responseOutputDto = new ResponseOutputDto();
        }
        //    public async Task<IEnumerable<Aircraft>> Get(string model)
        //    {
        //        //using (OracleConnection conn = new OracleConnection(configuration["AppSettings:ConnectionString"]))
        //        using (var connection = new SqlConnection(configuration["AppSettings:ConnectionString"]))
        //{
        //            await connection.OpenAsync();

        //            aircraft = await connection.QueryAsync<Aircraft>("GetAircraftByModel",
        //                                new
        //                                {
        //                                    Model = model
        //                                },
        //                                commandType: CommandType.StoredProcedure);
        //        }

        //    }
        public async Task<ResponseOutputDto> GetMultipleAsync<T>(string queryTextOrProcedureName, SqlDynamicParameters dynamicParameters, bool isCommandTypeProcedure = true) where T : class
        {
            IEnumerable<T> results = null;

            try
            {
                using (var conn = new SqlConnection(configuration["AppSettings:ConnectionString"]))
                {

                    results = await conn.QueryAsync<T>(queryTextOrProcedureName, dynamicParameters, commandType: isCommandTypeProcedure == true ? CommandType.StoredProcedure : CommandType.Text);
                    _responseOutputDto.Success<IEnumerable<T>>(results);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                _responseOutputDto.Error(error);
            }
            return _responseOutputDto;
        }
        public async Task<ResponseOutputDto> GetSingleAsync<T>(string queryTextOrProcedureName, SqlDynamicParameters dynamicParameters, bool isCommandTypeProcedure = true) where T : class
        {

            try
            {
                using (var conn = new SqlConnection(configuration["AppSettings:ConnectionString"]))
                {

                    var result = await conn.QueryFirstOrDefaultAsync<T>(queryTextOrProcedureName, dynamicParameters, commandType: isCommandTypeProcedure == true ? CommandType.StoredProcedure : CommandType.Text);
                    _responseOutputDto.Success<T>(result);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                _responseOutputDto.Error(error);
            }
            return _responseOutputDto;
        }
        public async Task<ResponseOutputDto> Execute<T>(string queryTextOrProcedureName, SqlDynamicParameters dynamicParameters, bool isCommandTypeProcedure = true) where T : class
        {

            try
            {
                using (var conn = new SqlConnection(configuration["AppSettings:ConnectionString"]))
                {

                    var result = await conn.ExecuteAsync(queryTextOrProcedureName, dynamicParameters, commandType: isCommandTypeProcedure == true ? CommandType.StoredProcedure : CommandType.Text);
                    _responseOutputDto.Success<T>(null);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                _responseOutputDto.Error(error);
            }
            return _responseOutputDto;
        }
    }
}
