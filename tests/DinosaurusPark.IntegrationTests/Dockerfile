FROM microsoft/dotnet:2.2-sdk
WORKDIR /src
COPY . .
WORKDIR /src/tests/DinosaurusPark.IntegrationTests
ENTRYPOINT ["dotnet"]
CMD ["test", "-v", "n"]