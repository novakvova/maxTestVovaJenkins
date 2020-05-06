FROM mcr.microsoft.com/dotnet/core/sdk:2.2
MAINTAINER carsale team
WORKDIR /app
COPY . /app
RUN apt update -y && apt install -y sudo && apt install -y curl
RUN curl -sL https://deb.nodesource.com/setup_12.x | sudo bash
RUN apt install -y nodejs
RUN npm install ClientApp/
ENTRYPOINT ["dotnet", "run"]
