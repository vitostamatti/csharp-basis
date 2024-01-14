# Basic IMS Rest Api

- Run Migrations
```bash
dotnet ef migrations add <MigrationName> --project ./src/MicroIMS.Infrastructure   --startup-project ./src/MicroIMS.Api
```

- Update database
```bash
dotnet ef database update --project ./src/MicroIMS.Infrastructure   --startup-project ./src/MicroIMS.Api
```

- Run
```bash
dotnet run --project ./src/MicroIMS.Api
```