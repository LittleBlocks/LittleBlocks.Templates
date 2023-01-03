FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR  /src
COPY *.sln ./
COPY LittleBlocks.Template.WebApi/*.csproj ./LittleBlocks.Template.WebApi/
COPY LittleBlocks.Template.WebApi.IntegrationTests/*.csproj ./LittleBlocks.Template.WebApi.IntegrationTests/
COPY LittleBlocks.Template.Core/*.csproj ./LittleBlocks.Template.Core/
COPY LittleBlocks.Template.Core.UnitTests/*.csproj ./LittleBlocks.Template.Core.UnitTests/
COPY LittleBlocks.Template.Common/*.csproj ./LittleBlocks.Template.Common/
COPY LittleBlocks.Template.Client/*.csproj ./LittleBlocks.Template.Client/
RUN dotnet restore

COPY . .
WORKDIR /src
RUN dotnet build -c Release -o /app/build
RUN dotnet test -c Release

FROM build AS publish
WORKDIR /src/LittleBlocks.Template.WebApi
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LittleBlocks.Template.WebApi.dll"]
