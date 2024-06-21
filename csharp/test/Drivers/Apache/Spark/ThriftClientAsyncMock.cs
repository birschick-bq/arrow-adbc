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

namespace Apache.Arrow.Adbc.Tests.Drivers.Apache.Spark
{
    internal class ThriftClientAsyncMock : MockDataSourceBase<TCLIService.IAsync>
    {
        private ThriftClientAsyncMock(TCLIService.IAsync proxy) : base(proxy)
        {
        }

        internal static MockDataSourceBase<TCLIService.IAsync> NewInstance()
        {
            var result = new ThriftClientAsyncMock(new ThriftClientAsyncProxy());

            return result;
        }

        internal class ThriftClientAsyncProxy : TCLIService.IAsync
        {
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

            public Task<TGetTableTypesResp> GetTableTypes(TGetTableTypesReq req, CancellationToken cancellationToken = default)
            {
                TStatus status = new(TStatusCode.SUCCESS_STATUS);
                StringArray.Builder stringBuilder = new();
                stringBuilder.Append("TABLE");
                stringBuilder.Append("VIEW");
                TStringColumn stringColumn = new(stringBuilder.Build());
                TTypeDesc stringTypeDesc = new()
                {
                    Types = [ new TTypeEntry() { PrimitiveEntry = new TPrimitiveTypeEntry(TTypeId.STRING_TYPE) } ]
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

                return Task.FromResult(resp);
            }

            public Task<TGetTypeInfoResp> GetTypeInfo(TGetTypeInfoReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

            public Task<TOpenSessionResp> OpenSession(TOpenSessionReq req, CancellationToken cancellationToken = default)
            {
                return Task.FromResult(new TOpenSessionResp()
                {
                    Status = new TStatus(TStatusCode.SUCCESS_STATUS),
                    ServerProtocolVersion = req.Client_protocol,
                    SessionHandle = new TSessionHandle(new THandleIdentifier(Guid.NewGuid().ToByteArray(), Guid.NewGuid().ToByteArray())),
                });
            }

            public Task<TRenewDelegationTokenResp> RenewDelegationToken(TRenewDelegationTokenReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

            public Task<TSetClientInfoResp> SetClientInfo(TSetClientInfoReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();

            public Task<TUploadDataResp> UploadData(TUploadDataReq req, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        }
    }
}
