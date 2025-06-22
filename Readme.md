# About
This is demo application - .NET 9 + Angular 20 (with Angular Material and Tailwind).

## Core details

## Project structure



## Frontend



## Backend

### Development
#### Run application
```
dotnet run
```


#### Create migration for DB sync
```
 dotnet ef migrations add <MIGRATION_NAME>
```
>This command will create new file with migration description for usage by **update** process


#### Sync migration to DB
```
dotnet ef database update
```

### Troubleshutting
In case not working migration process check if EF tool is installed
```
dotnet tool install --global dotnet-ef
```
