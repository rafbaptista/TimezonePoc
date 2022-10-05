#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Worker.Net.3.1/Worker.Net.3.1.csproj", "Worker.Net.3.1/"]
RUN dotnet restore "Worker.Net.3.1/Worker.Net.3.1.csproj"
COPY . .
WORKDIR "/src/Worker.Net.3.1"
RUN dotnet build "Worker.Net.3.1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Worker.Net.3.1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Worker.Net.3.1.dll"]