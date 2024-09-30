FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ENV TZ=America/Sao_Paulo
RUN ln -sf /usr/share/zoneinfo/posix/America/Sao_Paulo /etc/localtime
WORKDIR /app/ApiConsultorio
RUN sed -i 's/CipherString = DEFAULT@SECLEVEL=2/CipherString = DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

# copy csproj and restore as distinct layers
COPY *.sln . 
COPY ApiConsultorio.WebApi/*.csproj ./ApiConsultorio.WebApi/
COPY ApiConsultorio.Application/*.csproj ./ApiConsultorio.Application/
COPY ApiConsultorio.Domain/*.csproj ./ApiConsultorio.Domain/
COPY ApiConsultorio.Persistence/*.csproj ./ApiConsultorio.Persistence/
COPY ApiConsultorio.Infra/*.csproj ./ApiConsultorio.Infra/
COPY ApiConsultorio.UnitTest/*.csproj ./ApiConsultorio.UnitTest/

RUN dotnet restore

# copy everything else and build app
COPY ApiConsultorio.WebApi/. ./ApiConsultorio.WebApi/
COPY ApiConsultorio.Application/. ./ApiConsultorio.Application/
COPY ApiConsultorio.Domain/. ./ApiConsultorio.Domain/
COPY ApiConsultorio.Persistence/. ./ApiConsultorio.Persistence/
COPY ApiConsultorio.Infra/. ./ApiConsultorio.Infra/
COPY ApiConsultorio.UnitTest/. ./ApiConsultorio.UnitTest/

WORKDIR /app/ApiConsultorio
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app

ADD ApiConsultorio.pfx /root/.aspnet/https/

COPY --from=build /app/ApiConsultorio/out ./
ENTRYPOINT ["dotnet", "ApiConsultorio.WebApi.dll"]