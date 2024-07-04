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
using System.IO;

namespace Apache.Arrow.Adbc.Mocking
{

    public class ReplayableMockConfiguration
    {
        public static class ReplayableMockConstants
        {
            public const string Mode = "adbc.test.mock.replayable.mode";
            public const string DirectoryLocation = "adbc.test.mock.replayable.directory";
            public const string NoneMode = "none";
            public const string RecordMode = "record";
            public const string ReplayMode = "replay";
            public const string AutoRecordMode = "auto_record";
        }

        public enum Mode
        {
            AutoRecord,
            None,
            Record,
            Replay,
        }

        public ReplayableMockConfiguration(string? directoryLocation = default, Mode recordMode = Mode.None)
        {
            DirectoryLocation = directoryLocation ?? AppDomain.CurrentDomain.BaseDirectory;
            RecordMode = recordMode;
        }

        public ReplayableMockConfiguration(IReadOnlyDictionary<string, string>? configuration)
        {
            RecordMode = configuration != null
                ? configuration.TryGetValue(ReplayableMockConstants.Mode, out string? mode) && mode != null
                    ? mode.ToLowerInvariant() switch
                    {
                        ReplayableMockConstants.AutoRecordMode => Mode.AutoRecord,
                        ReplayableMockConstants.NoneMode => Mode.None,
                        ReplayableMockConstants.RecordMode => Mode.Record,
                        ReplayableMockConstants.ReplayMode => Mode.Replay,
                        _ => throw new ArgumentException($"Replayable mode '{mode}' is not supported.", nameof(configuration)),
                    }
                    : Mode.None
                : Mode.None;
            DirectoryLocation = configuration != null
                ? configuration.TryGetValue(ReplayableMockConstants.DirectoryLocation, out string? directoryLocation)
                    ? !string.IsNullOrEmpty(directoryLocation)
                        ? ((RecordMode == Mode.AutoRecord || RecordMode == Mode.Record) && IsDirectoryWritable(directoryLocation))
                          || (RecordMode == Mode.Replay && Directory.Exists(directoryLocation))
                            ? directoryLocation
                            : throw new ArgumentException($"Directory '{directoryLocation}' either does not exist or has incorrect access.", nameof(configuration))
                        : AppDomain.CurrentDomain.BaseDirectory
                    : AppDomain.CurrentDomain.BaseDirectory
                : AppDomain.CurrentDomain.BaseDirectory;
        }

        public string DirectoryLocation { get; }

        public Mode RecordMode { get; }

        private static bool IsDirectoryWritable(string dirPath, bool throwIfFails = false)
        {
            try
            {
                using (FileStream fs = File.Create(
                    Path.Combine(
                        dirPath,
                        Path.GetRandomFileName()
                    ),
                    1,
                    FileOptions.DeleteOnClose)
                )
                { }
                return true;
            }
            catch
            {
                if (throwIfFails)
                    throw;
                else
                    return false;
            }
        }
    }
}
