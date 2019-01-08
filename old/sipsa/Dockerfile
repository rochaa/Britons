FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# Build da aplicacao
COPY . ./
RUN dotnet publish ./sipsa -c Release -o publish

# Build da imagem
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app/sipsa/publish .

# ENV AQUI

EXPOSE 80
ENTRYPOINT ["dotnet", "sipsa.Views.dll"]