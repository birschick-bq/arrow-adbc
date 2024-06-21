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

using System.Collections.Generic;

namespace Apache.Arrow.Adbc.Mocking
{
    /// <summary>
    /// Defines the interface to expose support for a mocking data source driver implementation.
    /// The intention is that the mock will implement equivalent functionality to the server driver interface
    /// and that this will facilitates non-connected check-in tests.
    /// </summary>
    /// <typeparam name="T">An interface the mocking server will implement to mock the server driver functionality.</typeparam>
    internal interface IMockingDatabase<T> where T : class
    {
        /// <summary>
        /// Connects to the data source. If the optional mocking server <c>mock</c> is <c>null</c>, the returned <see cref="AdbcConnection"/> will use
        /// the actaul data source driver implementation and connect directly with the data source. If the mocking server <c>mock</c> is not <c>null</c>,
        /// then the mocking server must provice a full or partial implementation of the data source driver interface.
        /// </summary>
        /// <param name="properties">The connection properties used to connect to the server.</param>
        /// <param name="mock">The mocking data source implementation.</param>
        /// <returns></returns>
        internal MockingConnection<T> Connect(IReadOnlyDictionary<string, string>? properties, MockDataSourceBase<T>? mock);
    }
}
