#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FD.DataProvider.sln", "."]
COPY ["FD.SampleData/*.csproj", "./FD.SampleData/"]
COPY ["ConsoleDemo/*.csproj", "./ConsoleDemo/"]
COPY ["IdentityDemo/*.csproj", "./IdentityDemo/"]

RUN dotnet restore
COPY . .
WORKDIR "/src/FD.SampleData/."
RUN dotnet build "FD.SampleData.csproj" -c Release -o /app/build

#WORKDIR "/src/ConsoleDemo/."
#RUN dotnet build "ConsoleDemo.csproj" -c Release -o /app/build
#RUN dotnet build -c Release /app/build

WORKDIR "/src/IdentityDemo/."
RUN dotnet build "IdentityDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityDemo.dll"]