FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM node:10-alpine as build-node
WORKDIR /ClientApp
COPY /package.json .
COPY /package-lock.json .
RUN npm install
COPY CarSale/ClientApp/ . 
RUN npm run build  
FROM microsoft/dotnet:2.2-sdk AS build
ENV BuildingDocker true
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
COPY --from=build-node /ClientApp/build ./ClientApp/build
ENTRYPOINT ["dotnet", "CarSale.dll"]