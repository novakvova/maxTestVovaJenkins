FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine AS base
# Setup NodeJs
RUN apt update -y && apt install -y sudo && apt install -y curl
RUN curl -sL https://deb.nodesource.com/setup_12.x | sudo bash
RUN apt install -y nodejs

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["CarSale/CarSale.csproj", "CarSale/"]
RUN dotnet restore "CarSale/CarSale.csproj"
COPY . .
WORKDIR "/src/CarSale"
RUN dotnet build "CarSale.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CarSale.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
WORKDIR /app/ClientApp
RUN npm install
RUN npm rebuild node-sass
WORKDIR /app
ENTRYPOINT ["dotnet", "CarSale.dll"]