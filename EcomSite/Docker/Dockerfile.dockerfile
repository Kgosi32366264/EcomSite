FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA=Y

WORKDIR /app

COPY . .

RUN /opt/mssql/bin/sqlservr --accept-eula & sleep 10 \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -i apply-migrations.sql

EXPOSE 1433