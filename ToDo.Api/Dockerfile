#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ToDo.Api/ToDo.Api.csproj", "ToDo.Api/"]
COPY ["LogisticInfrastructure/ToDo.Infrastructure.csproj", "LogisticInfrastructure/"]
COPY ["ToDo.Domain/ToDo.Domain.csproj", "ToDo.Domain/"]
COPY ["ToDo.Application/ToDo.Application.csproj", "ToDo.Application/"]
COPY ["Framework/Logistic.Framework.csproj", "Framework/"]
COPY ["Logistic.Service/Logistic.Service.csproj", "Logistic.Service/"]
RUN dotnet restore "ToDo.Api/ToDo.Api.csproj"
COPY . .
WORKDIR "/src/ToDo.Api"
RUN dotnet build "ToDo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDo.Api.dll"]