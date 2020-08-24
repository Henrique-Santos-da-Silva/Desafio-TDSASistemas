FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
COPY . .

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet TDSASistemas.Desafio.Backend.dll