FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /src
COPY . .
WORKDIR /src/tests/DinosaursPark.IntegrationTests
ENTRYPOINT ["dotnet"]
CMD ["test", "-v", "n"]