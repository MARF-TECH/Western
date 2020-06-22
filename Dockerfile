#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-nanoserver-1909 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1909 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["Western.sln", "./"]
COPY ["Western/Western.csproj", "Western/"]
COPY ["Western.Core/Western.Core.csproj", "Western.Core/"]
COPY ["Western.Test/Western.Test.csproj", "Western.Test/"] 

# restore for all projects
RUN dotnet restore Western.sln

# copies the rest of your code
COPY . .
WORKDIR "/src"

# build
RUN dotnet build Western/Western.csproj -c Release -o /app/build

# test
#FROM build as testrunner
#WORKDIR /src/western.test
#LABEL test=true
#RUN dotnet tool install dotnet-reportgenerator-globaltool --tool-path /tools
#RUN dotnet test --logger "trx;LogFileName=western_test_results.xml" /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=/out/testresults/coverage/ /p:Exclude="[xunit.*]*" --results-directory /out/testresults
#RUN /tools/reportgenerator "-reports:/out/testresults/coverage/.cobertura.xml" "-targetdir:/out/testresults/coverage/reports" "-reporttypes:HTMLInline;HTMLChart"
#
# publish 
FROM build AS publish
RUN dotnet publish Western/Western.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Western.dll"]


