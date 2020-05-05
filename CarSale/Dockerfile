FROM microsoft/dotnet:2.2-aspnetcore-runtime 
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

FROM microsoft/dotnet:2.2-sdk 
WORKDIR /src
COPY ["CarSale/CarSale.csproj", "CarSale/"]
RUN dotnet restore "CarSale/CarSale.csproj"
COPY . .
WORKDIR "/src/CarSale"
RUN dotnet build "CarSale.csproj" -c Release -o /app

FROM build 
RUN dotnet publish "CarSale.csproj" -c Release -o /app

FROM base 
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CarSale.dll"]