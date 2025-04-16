#!/bin/bash

# install .NET 9.0 ASP.NET Core Runtime
wget https://aka.ms/install-dotnet.sh -O install-dotnet.sh
chmod +x install-dotnet.sh
./install-dotnet.sh --channel 9.0 --runtime aspnetcore

# 환경변수 설정
echo 'ENV="development"'		| sudo tee -a /etc/environment
echo 'MYSQL_HOST="localhost"' 	| sudo tee -a /etc/environment
echo 'MYSQL_PORT="3306"'		| sudo tee -a /etc/environment
echo 'MYSQL_UID="daga_server"'	| sudo tee -a /etc/environment
echo 'MYSQL_PWD="daga1234!"'	| sudo tee -a /etc/environment

