FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app/ApiConsultorio

# copy csproj and restore as distinct layers
COPY *.sln . 
COPY ApiConsultorio.WebApi/*.csproj ./ApiConsultorio.WebApi/
COPY ApiConsultorio.Application/*.csproj ./ApiConsultorio.Application/
COPY ApiConsultorio.Domain/*.csproj ./ApiConsultorio.Domain/
COPY ApiConsultorio.Persistence/*.csproj ./ApiConsultorio.Persistence/
COPY ApiConsultorio.UnitTest/*.csproj ./ApiConsultorio.UnitTest/

RUN dotnet restore

# copy everything else and build app
COPY ApiConsultorio.WebApi/. ./ApiConsultorio.WebApi/
COPY ApiConsultorio.Application/. ./ApiConsultorio.Application/
COPY ApiConsultorio.Domain/. ./ApiConsultorio.Domain/
COPY ApiConsultorio.Persistence/. ./ApiConsultorio.Persistence/
COPY ApiConsultorio.UnitTest/. ./ApiConsultorio.UnitTest/

WORKDIR /app/ApiConsultorio
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app

COPY --from=build /app/ApiConsultorio/out ./
ENTRYPOINT ["dotnet", "ApiConsultorio.WebApi.dll"]