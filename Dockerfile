FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["milanesapp/*", "milanesapp/"]

ENV PATH="${PATH}:/root/.dotnet/tools"