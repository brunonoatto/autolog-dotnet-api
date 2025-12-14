# Estágio 1: Build (Compilação)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas o arquivo de projeto primeiro (para aproveitar cache de dependências)
COPY ["autolog-dotnet-api.csproj", "."]
RUN dotnet restore "autolog-dotnet-api.csproj"

# Copia todo o resto do código
COPY . .
RUN dotnet build "autolog-dotnet-api.csproj" -c Release -o /app/build

# Publica a aplicação
FROM build AS publish
RUN dotnet publish "autolog-dotnet-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estágio 2: Runtime (Execução - Imagem final mais leve)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8443

# Variável de ambiente para escutar na porta correta (importante para Cloud)
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=publish /app/publish .

# Copia o bundle de migração da pasta gerada pelo GitHub Actions para a raiz do contêiner
RUN if [ -f publish-output/efbundle ]; then \
    cp publish-output/efbundle /efbundle; \
fi

ENTRYPOINT ["dotnet", "autolog-dotnet-api.dll"]