FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine AS base
# Setup NodeJs
RUN apt-get help

RUN apt update && \
    apt install -y wget && \
    apt install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_8.x | bash - && \
    apt install -y build-essential nodejs
RUN npm install @angular/cli -g
# End setup

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