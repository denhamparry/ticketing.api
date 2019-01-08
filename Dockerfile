FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY api/*.csproj ./api/
RUN dotnet restore api/

# copy everything else and build app
COPY api/. ./api/
WORKDIR /app/api
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/api/out ./
EXPOSE 80 443
ENTRYPOINT ["dotnet", "ticketing.api.dll"]
