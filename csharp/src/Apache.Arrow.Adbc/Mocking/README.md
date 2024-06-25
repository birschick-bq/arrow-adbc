# Mocking Interface for Disconnected Unit Tests

## Motivation

The data source drivers, by their nature connect to services to exchange data.
Properly testing against those data sources is key to integration testing and
ensuring the driver works correctly with that data source.

However, it is not always possible or efficient to connect directly to data sources
to test the driver implementation. This may be due to the cost and allocation of resources,
credential management, and time involved in running tests against a live service.

Mocking provides a way to imitate the behavior of a data source service without actually
connecting to a data source service.

In this model, we are providing a mechanism to inject a mock data source driver into
the ADBC driver. The mock data source driver must reliably imitate the original
data source driver to produce the same results, as if the data source had been called.

## What the mock interface purport to solve

1. Reduce and remove dependency on live data source for testing.
1. Add automated testing on pull requests.
1. Exercise the drivers implementation.
1. Measurement and report code coverage in the unit tests.
1. Detect and avoid code regressions.

## What the mock interface won't solve

1. Drivers using interop to load the driver. There is no injection interface at the that layer.
1. Code coverage won't measure coverage of source code that represents the data source driver, e.g., Thrift generated implementation.

## Things to Consider

1. Does the mock interface prevent consumers of the driver from using the this interface?
   - _Answer_: The interfaces are marked as `internal`.
1. Is the injection interface flexible enough handle the complete data source driver implemenation?
   - _Answer_: The generic mock interface allows any interface to be used. So the implementor is free to create their own custom wrapper.
1. Will the injection interface introduce any security risk?
   - _Answer_: The malicious user would need to use reflection to get to the interface and then trick the user into using the
   improperly signed assembly.
1. Is the injection interface reusable with more than one driver implementation?
   - _Answer_: It is likely that a record and playback mock interface could be used in all scenerios.

## Overview

### IMockingDatabase

The point of injection for the mock is through the `IMockingDatabase` method
`internal MockingConnection<T> Connect(IReadOnlyDictionary<string, string>? properties, MockDataSourceBase<T>? mock);`

Here this method is used to pass an optional data source mock object. The type `T` is the interface the mock
must implement - either wholly or partially.

If the passed mock object is `null`, then the driver will use the actual data source driver implementation and work live with the
data source server.

### MockingConnection\<T\>

The abstract class `MockingConnection<T>` inherits from `AdbcConnection`. The type `T` is the interface the mock
must implement - either wholly or partially.

The constructor, `protected MockingConnection(MockDataSourceBase<T>? mock)`, takes an optional mock object. If the passed mock object is `null`,
then the driver will use the actual data source driver implementation and work live with the data source server.

The class contains the property `internal T? DataSourceDriverProxy { get; }` where the inherited class can access the mock proxy implementation of
the data source driver.

As well, the inherited class must provide an implementation of `internal abstract Task<T> NewDataSourceDriverAsync()` to generate a live
data source driver to the mock. The intended use case is for the mock to be able to interact with the live server once to record
the expected result.

If the passed mock object is not `null`, the `MockingConnection<T>` connects the
proxy (`DataSourceDriverProxy`) and live data source driver (`NewDataSourceDriverAsync`)

### MockDataSourceBase<T>

This is the container for the mocking implementation. The type `T` is the interface the mock
must implement - either wholly or partially.

The constructor `public MockDataSourceBase(T proxy)` take a data source proxy implemenation.

The property `internal T DataSourceDriverProxy { get; }` provides access to the data source proxy implemenation.

The property `internal Func<Task<T>>? NewDataSourceDriverAsync { get; set; }` allow the MockingConnection to assign its
data source driver factory to be assigned to the mocking container.

### ThriftClientAsyncMock : MockDataSourceBase<TCLIService.IAsync>

The `ThriftClientAsyncMock` class is an implemenation of a moccking container and data source proxy for the `TCLIService.IAsync` interface.
The `ThriftClientAsyncMock.ThriftClientAsyncProxy` implements the `TCLIService.IAsync` interface.

### MockingTestBase<TConfig, TMock>

This class extends `TestBase` and adds support for a mock implemenation.

### SparkDatabase

Adds the implemenation of `IMockingDatabase<TCLIService.IAsync>` to pass the optional mock object to the connection object.

### HiveServer2Connection

Extends `MockingConnection<TCLIService.IAsync>` to take an optional mock object. This class uses proxy object (`DataSourceDriverProxy`) if
it is not null, otherwise, it uses the live data source driver.
