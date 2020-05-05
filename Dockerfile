FROM microsoft/dotnet:2.2-sdk-alpine
WORKDIR /source
EXPOSE 80
#EXPOSE 5001
#RUN curl -sL https://deb.nodesource.com/setup_10.x | bash -
#RUN apt-get install -y nodejs
RUN apk --no-cache add nodejs nodejs-npm
COPY *CarSale/CarSale.csproj .
RUN dotnet restore
COPY ./ ./
RUN dotnet publish "./CarSale.csproj" --output "./dist" --configuration Release --no-restore
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=microsoft/dotnet:2.2-sdk-alpine /source/dist .
ENTRYPOINT ["dotnet", "CarSale.dll"]