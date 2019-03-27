FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY SeanDotNetDocker/SeanDotNetDocker.csproj SeanDotNetDocker/
RUN dotnet restore SeanDotNetDocker/SeanDotNetDocker.csproj
COPY . .
WORKDIR /src/SeanDotNetDocker
RUN dotnet build SeanDotNetDocker.csproj -c Release -o /app
EXPOSE 80

FROM build AS publish
RUN dotnet publish SeanDotNetDocker.csproj -c Release -o /app
EXPOSE 80

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "SeanDotNetDocker.dll"]
