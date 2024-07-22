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
using System.Threading;
using System.Threading.Tasks;
using Apache.Arrow.Ipc;

namespace Apache.Arrow.Adbc.Drivers.Replayable
{
    internal class ListArrayStream : IArrowArrayStream
    {
        private readonly IReadOnlyList<RecordBatch> _recordBatches;

        // start at -1 to use the count the number of calls as the index
        private int _calls = -1;

        /// <summary>
        /// Initializes the ReplayedArrayStream.
        /// </summary>
        /// <param name="schema">
        /// The Arrow schema.
        /// </param>
        /// <param name="recordBatches">
        /// A list of record batches.
        /// </param>
        public ListArrayStream(Schema schema, IReadOnlyList<RecordBatch> recordBatches)
        {
            Schema = schema;
            _recordBatches = recordBatches;
        }

        public Schema Schema { get; }

        public void Dispose() { }

        /// <summary>
        /// Moves through the list of record batches.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional cancellation token.
        /// </param>
        public ValueTask<RecordBatch> ReadNextRecordBatchAsync(CancellationToken cancellationToken = default)
        {
            _calls++;
            return _calls < _recordBatches.Count ? new ValueTask<RecordBatch>(_recordBatches[_calls]) : new ValueTask<RecordBatch>();
        }
    }
}
