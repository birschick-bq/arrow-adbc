% Generated by roxygen2: do not edit by hand
% Please edit documentation in R/adbcbigquery-package.R
\name{adbcbigquery}
\alias{adbcbigquery}
\alias{adbc_database_init.adbcbigquery_driver_bigquery}
\alias{adbc_connection_init.adbcbigquery_database}
\alias{adbc_statement_init.adbcbigquery_connection}
\title{ADBC BigQuery Driver}
\usage{
adbcbigquery()

\method{adbc_database_init}{adbcbigquery_driver_bigquery}(driver, ..., token = NULL)

\method{adbc_connection_init}{adbcbigquery_database}(database, ...)

\method{adbc_statement_init}{adbcbigquery_connection}(connection, ...)
}
\arguments{
\item{driver}{An \code{\link[adbcdrivermanager:adbc_driver]{adbc_driver()}}.}

\item{...}{Extra key/value options passed to the driver.}

\item{token}{A token obtained from \code{\link[bigrquery:bq_token]{bigrquery::bq_token()}} or
\code{\link[gargle:token_fetch]{gargle::token_fetch()}}. This is the easiest way to authenticate.}

\item{database}{An \link[adbcdrivermanager:adbc_database_init]{adbc_database}.}

\item{connection}{An \link[adbcdrivermanager:adbc_connection_init]{adbc_connection}}
}
\value{
An \code{\link[adbcdrivermanager:adbc_driver_void]{adbcdrivermanager::adbc_driver()}}
}
\description{
ADBC BigQuery Driver
}
\examples{
adbcbigquery()

}
