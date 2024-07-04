/*
* Licensed to the Apache Software Foundation (ASF) under one or more
* contributor license agreements.  See the NOTICE file distributed with
* this work for additional information regarding copyright ownership.
* The ASF licenses this file to You under the Apache License, Version 2.0
* (the "License"); you may not use this file except in compliance with
* the License.  You may obtain a copy of the License at
*
*    http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Apache.Arrow.Adbc.Mocking;
using Apache.Hive.Service.Rpc.Thrift;
using Thrift.Protocol;

namespace Apache.Arrow.Adbc.Tests.Drivers.Apache.Spark
{
    internal class ThriftClientAsyncMock : IMockDataSource<TCLIService.IAsync>, TCLIService.IAsync
    {
        private readonly Lazy<Task<TCLIService.IAsync>> _client;
        private readonly Dictionary<TBase, TBase> _cache = [];
        private readonly ReplayableMockConfiguration _replayableMockConfiguration;

        internal class ThriftClientAsyncMockFactory : IMockDataSourceFactory<TCLIService.IAsync>
        {
            public IMockDataSource<TCLIService.IAsync> NewInstance(IReadOnlyDictionary<string, string>? properties, Func<Task<TCLIService.IAsync>> newDataSourceDriverAsync)
            {
                return new ThriftClientAsyncMock(properties, new Lazy<Task<TCLIService.IAsync>>(newDataSourceDriverAsync));
            }
        }

        private ThriftClientAsyncMock(IReadOnlyDictionary<string, string>? properties, Lazy<Task<TCLIService.IAsync>> client)
        {
            _client = client;
            _replayableMockConfiguration = new ReplayableMockConfiguration(properties);
        }

        public TCLIService.IAsync DataSourceDriverProxy => this;

        public Task<TCancelDelegationTokenResp> CancelDelegationToken(TCancelDelegationTokenReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TCancelOperationResp> CancelOperation(TCancelOperationReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TCloseOperationResp> CloseOperation(TCloseOperationReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TCloseSessionResp> CloseSession(TCloseSessionReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TDownloadDataResp> DownloadData(TDownloadDataReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TExecuteStatementResp> ExecuteStatement(TExecuteStatementReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TFetchResultsResp> FetchResults(TFetchResultsReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TGetCatalogsResp> GetCatalogs(TGetCatalogsReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TGetColumnsResp> GetColumns(TGetColumnsReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TGetCrossReferenceResp> GetCrossReference(TGetCrossReferenceReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TGetDelegationTokenResp> GetDelegationToken(TGetDelegationTokenReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TGetFunctionsResp> GetFunctions(TGetFunctionsReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TGetInfoResp> GetInfo(TGetInfoReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TGetOperationStatusResp> GetOperationStatus(TGetOperationStatusReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TGetPrimaryKeysResp> GetPrimaryKeys(TGetPrimaryKeysReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TGetQueryIdResp> GetQueryId(TGetQueryIdReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TGetResultSetMetadataResp> GetResultSetMetadata(TGetResultSetMetadataReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TGetSchemasResp> GetSchemas(TGetSchemasReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TGetTablesResp> GetTables(TGetTablesReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public async Task<TGetTableTypesResp> GetTableTypes(TGetTableTypesReq req, CancellationToken cancellationToken = default)
        {
            return _replayableMockConfiguration.RecordMode == ReplayableMockConfiguration.Mode.None
                ? await Task.FromResult(GetMockTableTypesResponse())
                : await GetCachedOrLive(req, (await _client.Value).GetTableTypes, cancellationToken);
        }

        private static TGetTableTypesResp GetMockTableTypesResponse()
        {
            TStatus status = new(TStatusCode.SUCCESS_STATUS);
            StringArray.Builder stringBuilder = new();
            stringBuilder.Append("TABLE");
            stringBuilder.Append("VIEW");
            TStringColumn stringColumn = new(stringBuilder.Build());
            TTypeDesc stringTypeDesc = new()
            {
                Types = [new TTypeEntry() { PrimitiveEntry = new TPrimitiveTypeEntry(TTypeId.STRING_TYPE) }]
            };
            TGetTableTypesResp resp = new(status)
            {
                DirectResults = new()
                {
                    ResultSet = new(status)
                    {
                        ResultSetMetadata = new(status)
                        {
                            Schema = new()
                            {
                                Columns = [new TColumnDesc("table_type", stringTypeDesc, 0)],
                            },
                        },
                        Results = new()
                        {
                            ColumnCount = 1,
                            Columns = [new TColumn() { StringVal = stringColumn }],
                        },
                    },
                },
            };
            return resp;
        }

        public Task<TGetTypeInfoResp> GetTypeInfo(TGetTypeInfoReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public async Task<TOpenSessionResp> OpenSession(TOpenSessionReq req, CancellationToken cancellationToken = default)
        {
            return _replayableMockConfiguration.RecordMode == ReplayableMockConfiguration.Mode.None
                ? await Task.FromResult(new TOpenSessionResp()
                {
                    Status = new TStatus(TStatusCode.SUCCESS_STATUS),
                    ServerProtocolVersion = req.Client_protocol,
                    SessionHandle = new TSessionHandle(new THandleIdentifier(Guid.NewGuid().ToByteArray(), Guid.NewGuid().ToByteArray())),
                })
                : await GetCachedOrLive(req, (await _client.Value).OpenSession, cancellationToken);
        }

        public Task<TRenewDelegationTokenResp> RenewDelegationToken(TRenewDelegationTokenReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TSetClientInfoResp> SetClientInfo(TSetClientInfoReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public Task<TUploadDataResp> UploadData(TUploadDataReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        private async Task<TResp> GetCachedOrLive<TReq, TResp>(TReq req, Func<TReq, CancellationToken, Task<TResp>> function, CancellationToken cancellationToken) where TReq : TBase where TResp : TBase
        {
            if (_cache.ContainsKey(req) && _cache[req] is TResp cachedResp) return cachedResp;

            if (_client == null)
            {
                throw new InvalidOperationException();
            }

            TResp actualResp = await function(req, cancellationToken);
            _cache[req] = actualResp;

            // TODO: Serialize/write the cache

            return actualResp;
        }
    }
}
