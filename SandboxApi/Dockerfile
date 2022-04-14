FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SandboxApi/SandboxApi.csproj", "SandboxApi/"]
RUN dotnet restore "SandboxApi/SandboxApi.csproj"
COPY . .
WORKDIR "/src/SandboxApi"
RUN dotnet build "SandboxApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SandboxApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SandboxApi.dll"]
