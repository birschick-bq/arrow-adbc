﻿/*
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

using System.Threading.Tasks;

namespace Apache.Arrow.Adbc.Mocking
{
    /// <summary>
    /// Provides support for a <see cref="AdbcConnection"/> where it supports using a mocking data source implementation.
    /// </summary>
    /// <typeparam name="T">An data source interface the mock will implement to mimick the data source driver functionality.</typeparam>
    internal abstract class MockingConnection<T> : AdbcConnection where T : class
    {
        /// <summary>
        /// Constructs an new <see cref="MockingConnection{T}"/> given an optional mocking data source implementation <c>mock</c>.
        /// </summary>
        /// <param name="mock">The mocking data source implementation.</param>
        protected MockingConnection(MockDataSourceBase<T>? mock)
        {
            if (mock == null) return;

            DataSourceDriverProxy = mock.DataSourceDriverProxy;
            mock.NewDataSourceDriverAsync = NewDataSourceDriverAsync;
        }

        /// <summary>
        /// The data source proxy implementation for the data source driver interface.
        /// </summary>
        internal T? DataSourceDriverProxy { get; }

        /// <summary>
        /// Provides a way to create a new instance of the data source's connected implementation.
        /// Mocking servers can use this, for example, to record an integration scenario for later playback.
        /// </summary>
        /// <returns></returns>
        internal abstract Task<T> NewDataSourceDriverAsync();
    }
}