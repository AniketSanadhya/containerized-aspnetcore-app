# ASP.NET CORE BUILD STAGE
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS dotnet-build

WORKDIR /app
COPY    . .
RUN dotnet restore
RUN dotnet publish -c Release -o /publish
# RUN MKDIR -p publish/wwwroot


# ANGULAR BUILD
FROM node:12.7-alpine AS ng-build

WORKDIR /app
COPY ./ClientApp/package.json /app

RUN npm install
COPY ./ClientApp /app
RUN npm run build --prod


# RUNTIME IMAGE STAGE
FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /publish
COPY --from=dotnet-build /publish .
COPY --from=ng-build /app/dist/ClientApp /publish/wwwroot

ENTRYPOINT [ "dotnet","/publish/DemoApp.dll" ]


