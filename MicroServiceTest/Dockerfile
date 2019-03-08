

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 60220
EXPOSE 44360

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["MicroServiceTest/MicroServiceTest.csproj", "MicroServiceTest/"]
RUN dotnet restore "MicroServiceTest/MicroServiceTest.csproj"
COPY . .
WORKDIR "/src/MicroServiceTest"
RUN dotnet build "MicroServiceTest.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MicroServiceTest.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroServiceTest.dll"]