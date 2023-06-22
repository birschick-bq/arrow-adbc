
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
<!-- README.md is generated from README.Rmd. Please edit that file -->

# adbcflightsql

<!-- badges: start -->
<!-- badges: end -->

The goal of adbcflightsql is to provide a low-level developer-facing
interface to the Arrow Database Connectivity (ADBC) FlightSQL driver.

## Installation

You can install the development version of adbcflightsql from
[GitHub](https://github.com/) with:

``` r
# install.packages("remotes")
remotes::install_github("apache/arrow-adbc/r/adbcdrivermanager", build = FALSE)
remotes::install_github("apache/arrow-adbc/r/adbcflightsql", build = FALSE)
```

## Example

This is a basic example which shows you how to solve a common problem.

``` r
library(adbcdrivermanager)

# Use the driver manager to connect to a database. This example URI is
# grpc://localhost:8080 and uses a Go FlightSQL/SQLite server docker image
uri <- Sys.getenv("ADBC_FLIGHTSQL_TEST_URI")
db <- adbc_database_init(adbcflightsql::adbcflightsql(), uri = uri)
con <- adbc_connection_init(db)

# Write a table
stmt <- adbc_statement_init(con)
adbc_statement_set_sql_query(
  stmt,
  "CREATE TABLE crossfit (exercise TEXT, difficulty_level INTEGER)"
)
adbc_statement_execute_query(stmt)
#> [1] 4
adbc_statement_release(stmt)

stmt <- adbc_statement_init(con)
adbc_statement_set_sql_query(
  stmt,
  "INSERT INTO crossfit values
    ('Push Ups', 3),
    ('Pull Ups', 5),
    ('Push Jerk', 7),
    ('Bar Muscle Up', 10);"
)
adbc_statement_execute_query(stmt)
#> [1] 4
adbc_statement_release(stmt)

# Query it
stmt <- adbc_statement_init(con)
stream <- nanoarrow::nanoarrow_allocate_array_stream()

adbc_statement_set_sql_query(stmt, "SELECT * from crossfit")
adbc_statement_execute_query(stmt, stream)
#> [1] -1
result <- tibble::as_tibble(stream)
adbc_statement_release(stmt)

result
#> # A tibble: 4 × 2
#>   exercise      difficulty_level
#>   <chr>                    <dbl>
#> 1 Push Ups                     3
#> 2 Pull Ups                     5
#> 3 Push Jerk                    7
#> 4 Bar Muscle Up               10
```