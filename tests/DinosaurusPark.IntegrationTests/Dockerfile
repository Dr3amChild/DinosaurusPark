FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster
WORKDIR /src
COPY . .
WORKDIR /src/tests/DinosaurusPark.IntegrationTests
ENTRYPOINT ["dotnet"]
CMD ["test", "-v", "n"]