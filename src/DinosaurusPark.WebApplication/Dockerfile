FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY . .
RUN dotnet publish ./src/DinosaurusPark.WebApplication/DinosaurusPark.WebApplication.csproj -c Release -o /app

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /app
EXPOSE 80
COPY --from=build /app .
ENTRYPOINT ["dotnet"]
CMD ["DinosaurusPark.WebApplication.dll"]