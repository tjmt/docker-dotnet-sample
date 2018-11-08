#Estágio de build.
FROM tjmt/dotnetcore:builder as build


#Estágio do publish
FROM build as publish
#RUN dotnet publish src/TJMT.Docker.DotNet.Samples/TJMT.Docker.DotNet.Samples.csproj -c ${CONFIGURATION} -o /app                  


#Estágio final
FROM dotnetcore:runtime as final
COPY --from=publish /app /app
WORKDIR /app
ENTRYPOINT dotnet TJMT.Docker.DotNet.Samples.dll