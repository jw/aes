#!/usr/bin/env bash

current_dir=$(pwd)
script_dir=$(dirname "$0")

root=${script_dir}/..
echo "Using this root: ${root}

echo "|"
echo "| PYTHON: ENCRYPT"
echo "|"
cd ${root}/python
poetry update
poetry run python aes/fernet.py

echo "|"
echo "| C#: DECRYPT"
echo "|"

cd ${root}/c#/aes
dotnet build
dotnet run

cd $current_dir
