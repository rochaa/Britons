FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# Build da aplicacao
COPY . ./
RUN dotnet publish ./sipsa.Web -c Release -o publish

# Build da imagem
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app/sipsa.Web/publish .

# ENV AQUI

EXPOSE 80
ENTRYPOINT ["dotnet", "sipsa.Web.Views.dll"]