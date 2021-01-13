#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PactTest.API/PactTest.API.csproj", "PactTest.API/"]
RUN dotnet restore "PactTest.API/PactTest.API.csproj"
COPY . .
WORKDIR "/src/PactTest.API"
RUN dotnet build "PactTest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PactTest.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PactTest.API.dll"]