FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TheMostSimpleApp.csproj", "."]
RUN dotnet restore "./TheMostSimpleApp.csproj"
COPY . .
WORKDIR "/src/."
ARG version=1.0.0
ENV VERSION $version
RUN dotnet build "TheMostSimpleApp.csproj" -c Release -o /app/build /p:Version="$VERSION"

FROM build AS publish
RUN dotnet publish "TheMostSimpleApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheMostSimpleApp.dll"]