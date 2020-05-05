FROM mcr.microsoft.com/dotnet/core/sdk:2.2
MAINTAINER carsale team
WORKDIR /app
COPY . /app
RUN apt update -y && apt install -y nodejs && apt install -y npm 
RUN cd ClientApp
RUN npm install
RUN cd ..
ENTRYPOINT ["dotnet", "run"]