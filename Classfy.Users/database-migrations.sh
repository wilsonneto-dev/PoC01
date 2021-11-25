#!/bin/sh
set -e

cd ./Modules/Users/Classfy.Users.Infra.Persistence.EF/

until /root/.dotnet/tools/dotnet-ef database update -s ../../../API/Classfy.Unified.API -v; do
>&2 echo "SQL Server is starting up, trying to migrations"
sleep 1
done

>&2 echo "finished"
