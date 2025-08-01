<!---
  Licensed to the Apache Software Foundation (ASF) under one
  or more contributor license agreements.  See the NOTICE file
  distributed with this work for additional information
  regarding copyright ownership.  The ASF licenses this file
  to you under the Apache License, Version 2.0 (the
  "License"); you may not use this file except in compliance
  with the License.  You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing,
  software distributed under the License is distributed on an
  "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
  KIND, either express or implied.  See the License for the
  specific language governing permissions and limitations
  under the License.
-->

# ADBC PostgreSQL Driver for Python

This package contains bindings for the [PostgreSQL driver][postgresql], using
the [driver manager][driver-manager] to provide a [DBAPI 2.0/PEP
249-compatible][dbapi] interface on top.

[dbapi]: https://peps.python.org/pep-0249/
[driver-manager]: https://arrow.apache.org/adbc/current/python/driver_manager.html
[postgresql]: https://arrow.apache.org/adbc/current/driver/postgresql.html

## Example

```python
import adbc_driver_postgresql.dbapi

uri = "postgresql://postgres:password@localhost:5432/postgres"
with adbc_driver_postgresql.dbapi.connect(uri) as conn:
    with conn.cursor() as cur:
        cur.execute("SELECT 1")
        print(cur.fetch_arrow_table())
```


## Building

Dependencies: a build of the PostgreSQL driver, and the
`adbc-driver-manager` Python package.  Optionally, install PyArrow to
use the DBAPI 2.0-compatible interface.

Set the environment variable `ADBC_POSTGRESQL_LIBRARY` to the path to
`libadbc_driver_postgresql.{dll,dylib,so}` before running `pip install`.

```
# If not already installed
pip install -e ../adbc_driver_manager

export ADBC_POSTGRESQL_LIBRARY=/path/to/libadbc_driver_postgresql.so
pip install --no-deps -e .
```

For users building from the arrow-adbc source repository, you can alternately use CMake to manage library dependencies and set environment variables for you. Assuming you specify ``-DADBC_DRIVER_POSTGRESQL=ON`` you can also add ``-DADBC_BUILD_PYTHON=ON`` to define a ``python`` target.

For example, assuming you run cmake from the project root:

```shell
cmake -S c -B build --preset debug -DADBC_BUILD_PYTHON=ON -DADBC_DRIVER_POSTGRESQL=ON
cmake --build build --target python
```

will properly build and install the Python library for you.

See [CONTRIBUTING.md](../../CONTRIBUTING.md) for details on the
general build process.

## Testing

A running instance of PostgreSQL is required.  For example, using Docker:

```shell
$ docker run -it --rm \
    -e POSTGRES_PASSWORD=password \
    -e POSTGRES_DB=tempdb \
    -p 5432:5432 \
    postgres
```

Then, to run the tests, set the environment variable specifying the
PostgreSQL URI before running tests:

```shell
$ export ADBC_POSTGRESQL_TEST_URI=postgresql://localhost:5432/postgres?user=postgres&password=password
$ pytest -vvx
```

See [CONTRIBUTING.md](../../CONTRIBUTING.md) for details on the
general test process.
