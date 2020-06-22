#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-nanoserver-1803 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1803 AS build
WORKDIR /src
COPY ["Western.Test/Western.Test.csproj", "Western.Test/"]
COPY ["Western.Core/Western.Core.csproj", "Western.Core/"]
RUN dotnet restore "Western.Test/Western.Test.csproj"
COPY . .
WORKDIR "/src/Western.Test"
RUN dotnet build "Western.Test.csproj" -c Release -o /app/build

# Run Test With Coverage
FROM build as testrunner
RUN dotnet tool install dotnet-reportgenerator-globaltool --tool-path /tools
RUN dotnet test --logger "trx;LogFileName=western_test_results.xml" /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=/out/testresults/coverage/ /p:Exclude="[xunit.*]*" --results-directory /out/testresults
