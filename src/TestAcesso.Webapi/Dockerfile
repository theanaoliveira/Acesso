#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TestAcesso.Webapi/TestAcesso.Webapi.csproj", "TestAcesso.Webapi/"]
COPY ["TestAcesso.Application/TestAcesso.Application.csproj", "TestAcesso.Application/"]
COPY ["TestAcesso.Domain/TestAcesso.Domain.csproj", "TestAcesso.Domain/"]
COPY ["TestAcesso.Infrastructure/TestAcesso.Infrastructure.csproj", "TestAcesso.Infrastructure/"]
RUN dotnet restore "TestAcesso.Webapi/TestAcesso.Webapi.csproj"
COPY . .
WORKDIR "/src/TestAcesso.Webapi"
RUN dotnet build "TestAcesso.Webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestAcesso.Webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestAcesso.Webapi.dll"]