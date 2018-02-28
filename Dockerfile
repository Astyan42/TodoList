FROM microsoft/dotnet:2.0-sdk AS Build

WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Business/*.csproj ./Business/
COPY Data/*.csproj ./Data/
COPY DomainObject/*.csproj ./DomainObject/
COPY TODOList/*.csproj ./TODOList/
RUN dotnet restore

COPY . .
WORKDIR /app
RUN dotnet build


FROM Build AS Publish
WORKDIR /app
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.0-sdk AS runtime
ENV ASPNETCORE_URLS http://+:80
WORKDIR /app
COPY --from=Publish /app/TODOList/out ./
ENTRYPOINT ["dotnet", "Service.dll"]