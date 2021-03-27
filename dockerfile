FROM mcr.microsoft.com/dotnet/sdk:5.0

WORKDIR /app
COPY    . .

RUN dotnet restore
RUN dotnet publish -o /publish

ENTRYPOINT [ "dotnet","/publish/DemoApp.dll" ]

# FROM node:12.7-alpine AS build

# WORKDIR /app

# COPY ./ClientApp/package.json /app

# RUN npm install

# COPY ./ClientApp /app

# RUN npm run build --prod