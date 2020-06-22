#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-nanoserver-1803 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1803 AS build
WORKDIR /src
COPY ["Western/Western.csproj", "Western/"]
COPY ["Western.Core/Western.Core.csproj", "Western.Core/"]
RUN dotnet restore "Western/Western.csproj"
COPY . .
WORKDIR "/src/Western"
RUN dotnet build "Western.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Western.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Western.dll"]