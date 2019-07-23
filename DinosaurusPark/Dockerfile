FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DinosaurusPark.csproj", ""]
RUN dotnet restore "DinosaurusPark.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "DinosaurusPark.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DinosaurusPark.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DinosaurusPark.dll"]