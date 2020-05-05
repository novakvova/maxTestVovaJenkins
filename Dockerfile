FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
FROM mcr.microsoft.com/dotnet/core/sdk:2.2
MAINTAINER carsale
WORKDIR /app
COPY . /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000
ENTRYPOINT ["dotnet", "run"]