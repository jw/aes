#!/usr/bin/env bash

current_dir=$(pwd)
script_dir=$(dirname "$0")

root=${script_dir}/..

root=`realpath ${root}`
echo "Using this root: ${root}"

echo '|'
echo '| PYTHON: ENCRYPT'
echo '|'

cd ${root}/python
poetry update
poetry run python aes/fernet.py ${root}

echo '|'
echo '| C#: DECRYPT'
echo '|'

cd ${current_dir}
cd ${root}/c#/aes
dotnet build
dotnet run Program.cs ${root}

cd $current_dir
