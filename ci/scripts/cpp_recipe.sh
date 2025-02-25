#!/usr/bin/env bash
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

# Build and test the C++ recipes in the documentation.

set -e

: ${ADBC_CMAKE_ARGS:=""}
: ${CMAKE_BUILD_TYPE:=Debug}

test_recipe() {
    local -r recipe="${1}"
    local -r source_dir="${2}"
    local -r install_dir="${3}"
    local -r build_dir="${4}"

    export DYLD_LIBRARY_PATH="${LD_LIBRARY_PATH}:${install_dir}/lib"
    export LD_LIBRARY_PATH="${LD_LIBRARY_PATH}:${install_dir}/lib"
    export GOEXPERIMENT=cgocheck2

    rm -rf "${build_dir}"
    mkdir -p "${build_dir}"
    pushd "${build_dir}"

    set -x
    cmake "${source_dir}/${recipe}/" \
          ${ADBC_CMAKE_ARGS} \
          -DCMAKE_BUILD_TYPE="${CMAKE_BUILD_TYPE}" \
          -DCMAKE_INSTALL_LIBDIR=lib \
          -DCMAKE_INSTALL_PREFIX="${install_dir}" \
          -DCMAKE_PREFIX_PATH="${install_dir}" \
          -DADBC_DRIVER_EXAMPLE_BUILD_TESTS=ON
    set +x

    cmake --build . --target install -j
    ctest \
        --output-on-failure \
        --no-tests=error
}

test_recipe "docs/source/cpp/recipe" "$@"
test_recipe "docs/source/cpp/recipe_driver" "$@"
