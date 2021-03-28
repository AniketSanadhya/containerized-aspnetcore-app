# A Demo App about managing Cars
The goal behind creating this app was for me to try out Docker and Containerizing apps. Following are the features:
- Asp.Net Core (5.0) Web APIs
- Angular 11 as front-end
- Entity Framework (5) for managing data received from Sql Server

I think the ultimate feature is the way to setup this app on any dev environment. All it requires is Docker Desktop installed and one single command to start things up: `docker-compose up`

Running `docker-compose up` will do the following things:
- It will download the SQL Server 2019 image from microsoft's repository and will be setup with basic credentials and access in a container.
- It will download our Demo Car App image from Azure Container Registry and Run it.

The Demo Car App image does the following things when built:
- Builds Asp.Net Core Web API using dotnet 5.0 sdk image from microsoft's registry
- Builds Angular App
- Copies the published static files from Angular to Asp.Net Core's wwwroot folder
- Runs the dll of our app from published folder serving the static files built from Angular

![image](https://user-images.githubusercontent.com/8235649/112764409-01e6ec00-9026-11eb-98b2-9b1cdb35786e.png)
