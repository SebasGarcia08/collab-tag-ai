FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore backend.csproj

COPY . ./
RUN dotnet publish backend.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app

EXPOSE 5000

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "backend.dll"]