FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

ENV APP_HOME /opt/app
RUN mkdir $APP_HOME
WORKDIR $APP_HOME

COPY AccountService/*.csproj $APP_HOME/AccountService/
COPY AccountService.API/*.csproj $APP_HOME/AccountService.API/
COPY CoreService/*.csproj $APP_HOME/CoreService/
RUN  cd $APP_HOME/AccountService && dotnet restore

COPY AccountService.API $APP_HOME/AccountService.API/
COPY AccountService $APP_HOME/AccountService/
COPY CoreService $APP_HOME/CoreService/
RUN cd $APP_HOME/AccountService && dotnet build

FROM build AS publish
WORKDIR $APP_HOME/AccountService
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
COPY --from=publish /opt/app/AccountService/out ./
ENTRYPOINT ["dotnet", "AccountService.dll"]