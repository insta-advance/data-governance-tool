FROM microsoft/dotnet:latest
ENV http_proxy 'http://87.254.212.120:8080'
COPY . /DataGovernanceTool
WORKDIR /DataGovernanceTool

#EXPOSE 5000

#ENV ASPNETCORE_URLS http://+:5000
#ENTRYPOINT dotnet run

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 5000
ENV ASPNETCORE_URLS http://+:5000
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
