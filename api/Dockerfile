# ---------- build ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Копіюємо csproj-и окремо для кешування restore
COPY api.sln ./
COPY api/api.csproj api/
COPY Domain/Domain.csproj Domain/
COPY DataAccess/DataAccess.csproj DataAccess/
RUN dotnet restore api/api.csproj

# Копіюємо решту і білдимо
COPY . .
RUN dotnet publish api/api.csproj -c Release -o /app/publish --no-restore

# ---------- runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "api.dll"]
