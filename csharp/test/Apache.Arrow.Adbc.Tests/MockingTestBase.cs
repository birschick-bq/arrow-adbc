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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.Arrow.Adbc.Mocking;
using Apache.Arrow.Ipc;
using Apache.Arrow.Types;
using Xunit;
using Xunit.Abstractions;

namespace Apache.Arrow.Adbc.Tests
{
    /// <summary>
    /// Provides a base class for ADBC tests.
    /// </summary>
    /// <typeparam name="T">A <see cref="TestConfiguration"/> type to use when accessing test configuration files.</typeparam>
    /// <typeparam name="M">A <see cref="MockDataSourceBase{T}"/> type to use for mocking tests</typeparam>
    /// <remarks>
    /// Constructs a new ProxyTestBase object with an output helper.
    /// </remarks>
    /// <param name="outputHelper">Test output helper for writing test output.</param>
    public abstract class MockingTestBase<T, M>(ITestOutputHelper? outputHelper) : TestBase<T>(outputHelper)
        where T : TestConfiguration
        where M : class
    {
        /// <summary>
        /// Gets a the Spark ADBC driver with settings from the <see cref="SparkTestConfiguration"/>.
        /// </summary>
        /// <param name="testConfiguration"><see cref="Tests.TestConfiguration"/></param>
        /// <param name="connectionOptions">A dictionary of connection options.</param>
        /// <param name="mock">An optional mocker server proxy implementation.</param>
        /// <returns></returns>
        protected AdbcConnection NewConnection(T? testConfiguration = default, IReadOnlyDictionary<string, string>? connectionOptions = default, MockDataSourceBase<M>? mock = default)
        {
            Dictionary<string, string> parameters = GetDriverParameters(testConfiguration ?? TestConfiguration);
            AdbcDatabase database = NewDriver.Open(parameters);
            IReadOnlyDictionary<string, string> options = connectionOptions ?? new Dictionary<string, string>();
            AdbcConnection connection = (database is IMockingDatabase<M> mockingDatabase)
                ? mockingDatabase.Connect(options, mock)
                : database.Connect(options);
            return connection;
        }
    }
}
