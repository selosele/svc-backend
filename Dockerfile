# 빌드 스테이지
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 모든 파일을 복사 후 복원
COPY . ./
RUN dotnet restore

# 빌드 및 퍼블리시
RUN dotnet publish -c Release -o /app/publish --no-restore

# 실행 스테이지
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# 빌드된 파일 복사
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Svc.dll"]
