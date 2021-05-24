#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pricing/Pricing.csproj", "Pricing/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "Pricing/Pricing.csproj"
COPY . .
WORKDIR "/src/Pricing"
RUN dotnet build "Pricing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pricing.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pricing.dll"]