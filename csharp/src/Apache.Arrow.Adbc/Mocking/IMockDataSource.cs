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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apache.Arrow.Adbc.Mocking
{
    /// <summary>
    /// A container for the mocking data source proxy implementation.
    /// </summary>
    /// <typeparam name="T">The data source driver interface to implement.</typeparam>
    public interface IMockDataSource<T> where T : class
    {
        /// <summary>
        /// The data source driver implementation.
        /// </summary>
        public T DataSourceDriverProxy { get; }

    }

    /// <summary>
    /// A factory interface to generate new instances of the mock data source.
    /// </summary>
    /// <typeparam name="T">The data source driver interface to implement.</typeparam>
    public interface IMockDataSourceFactory<T> where T : class
    {
        /// <summary>
        /// Creates a new instance of the mock data source.
        /// </summary>
        /// <param name="newDataSourceDriverAsync">The function that will provide an actual data source driver interface.</param>
        /// <returns></returns>
        public IMockDataSource<T> NewInstance(IReadOnlyDictionary<string, string>? properties, Func<Task<T>> newDataSourceDriverAsync);
    }
}
