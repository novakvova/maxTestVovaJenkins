FROM microsoft/dotnet:2.2-sdk-alpine
WORKDIR /source
EXPOSE 80
#EXPOSE 5001
#RUN curl -sL https://deb.nodesource.com/setup_10.x | bash -
#RUN apt-get install -y nodejs
RUN apk --no-cache add nodejs nodejs-npm
COPY *.csproj .
RUN dotnet restore
COPY ./ ./
RUN dotnet publish "./CarSale.csproj" --output "./dist" --configuration Release --no-restore
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=builder /source/dist .
ENTRYPOINT ["dotnet", "CarSale.dll"]
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
FROM mcr.microsoft.com/dotnet/core/sdk:2.2
MAINTAINER maksutroman
WORKDIR /app
COPY . /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000
ENTRYPOINT ["dotnet", "run"]