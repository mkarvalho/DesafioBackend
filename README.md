## Desafio Backend

### How to run

1.  Create a postgres container
```docker run --name postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 -d postgres```

2. Run on console to apply migration on database
```dotnet ef database update```

3. Run on console ```dotnet run```
4. Open on browser ```https://localhost:5001/swagger/index.html```
