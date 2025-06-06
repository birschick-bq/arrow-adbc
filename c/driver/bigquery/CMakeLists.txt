# Licensed to the Apache Software Foundation (ASF) under one
# or more contributor license agreements.  See the NOTICE file
# distributed with this work for additional information
# regarding copyright ownership.  The ASF licenses this file
# to you under the Apache License, Version 2.0 (the
# "License"); you may not use this file except in compliance
# with the License.  You may obtain a copy of the License at
#
#   http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing,
# software distributed under the License is distributed on an
# "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
# KIND, either express or implied.  See the License for the
# specific language governing permissions and limitations
# under the License.

include(GoUtils)

set(LDFLAGS "$<$<CONFIG:Release>:-s> $<$<CONFIG:Release>:-w>")
add_go_lib("${REPOSITORY_ROOT}/go/adbc/pkg/bigquery/"
           adbc_driver_bigquery
           SOURCES
           driver.go
           utils.h
           utils.c
           BUILD_TAGS
           driverlib
           CMAKE_PACKAGE_NAME
           AdbcDriverBigQuery
           PKG_CONFIG_NAME
           adbc-driver-bigquery
           SHARED_LINK_FLAGS
           ${LDFLAGS}
           DEFINES
           ${ADBC_TARGET_COMPILE_DEFINITIONS}
           OUTPUTS
           ADBC_LIBRARIES)

foreach(LIB_TARGET ${ADBC_LIBRARIES})
  target_include_directories(${LIB_TARGET} SYSTEM
                             INTERFACE ${REPOSITORY_ROOT} ${REPOSITORY_ROOT}/c/
                                       ${REPOSITORY_ROOT}/c/driver)
endforeach()

if(ADBC_TEST_LINKAGE STREQUAL "shared")
  set(TEST_LINK_LIBS adbc_driver_bigquery_shared)
else()
  set(TEST_LINK_LIBS adbc_driver_bigquery_static)
endif()

if(ADBC_BUILD_TESTS)
  add_test_case(driver_bigquery_test
                PREFIX
                adbc
                EXTRA_LABELS
                driver-bigquery
                SOURCES
                bigquery_test.cc
                EXTRA_LINK_LIBS
                adbc_driver_common
                adbc_validation
                ${TEST_LINK_LIBS})
  target_compile_features(adbc-driver-bigquery-test PRIVATE cxx_std_17)
  target_include_directories(adbc-driver-bigquery-test SYSTEM
                             PRIVATE ${REPOSITORY_ROOT}/c/ ${REPOSITORY_ROOT}/c/include/
                                     ${REPOSITORY_ROOT}/c/driver
                                     ${REPOSITORY_ROOT}/c/driver/common)
  adbc_configure_target(adbc-driver-bigquery-test)
endif()
