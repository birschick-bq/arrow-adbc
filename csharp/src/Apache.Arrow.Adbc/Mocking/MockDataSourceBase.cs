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
using System.Threading.Tasks;

namespace Apache.Arrow.Adbc.Mocking
{
    /// <summary>
    /// A container for the mocking data source proxy implementation.
    /// </summary>
    /// <typeparam name="T">The data source driver interface to implement.</typeparam>
    public abstract class MockDataSourceBase<T> where T : class
    {
        /// <summary>
        /// Constructs a container for the mocking data source proxy implementation.
        /// </summary>
        /// <param name="proxy">The data source driver proxy implementation.</param>
        public MockDataSourceBase(T proxy)
        {
            DataSourceDriverProxy = proxy;
        }

        /// <summary>
        /// Provides a function to generate an actual instance of the data source driver interface.
        /// </summary>
        internal Func<Task<T>>? NewDataSourceDriverAsync { get; set; }

        /// <summary>
        /// The data source driver implementation.
        /// </summary>
        internal T DataSourceDriverProxy { get; }

    }
}
