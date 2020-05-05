FROM microsoft/dotnet:2.1.2-aspnetcore-runtime
#install application for get HW info
RUN apt-get update
RUN apt-get install -y mc
RUN apt-get install -y curl
RUN apt-get install -y hwinfo
RUN apt-get install -y busybox
RUN apt-get install -y iputils-ping
RUN apt-get install -y nodejs
#National Language (locale) data
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT false
RUN apt-get install -y locales
RUN locale-gen uk_UA.UTF-8
ENV LC_ALL uk_UA.UTF-8
ENV LANG uk_UA.UTF-8
WORKDIR /app
EXPOSE 80
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash -
RUN apt-get install -y nodejs
FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["JNew/JNew.csproj", "JNew/"]
RUN dotnet restore "JNew/JNew.csproj"
COPY . .
WORKDIR "/src/JNew"
RUN dotnet build "JNew.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "JNew.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JNew.dll"]