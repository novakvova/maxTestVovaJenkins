FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM node:10-alpine as build-node
WORKDIR /ClientApp
COPY ClientApp/ .
COPY ClientApp/ .
RUN npm install
COPY ClientApp/ .  
FROM microsoft/dotnet:2.2-sdk AS build
ENV BuildingDocker true
WORKDIR /src
COPY ["CarSale.csproj", "CarSale/"]
RUN dotnet restore "CarSale/CarSale.csproj"
COPY . .
WORKDIR "/src/CarSale"
RUN dotnet build "CarSale.csproj" -c Release -o /app
FROM build AS publish
WORKDIR /app
ENTRYPOINT ["dotnet", "run"]