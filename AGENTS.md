# AGENTS.md

## Cursor Cloud specific instructions

### Overview
Marvel Comics Store is a .NET 5.0 ASP.NET Core Web API for a comic book store. It consumes the Marvel Developer API for comic listings and persists checkout data to MySQL via Entity Framework Core. See `README.md` for the Portuguese-language project description.

### System dependencies (pre-installed in snapshot)
- **.NET 5.0 SDK** (5.0.408) installed at `/usr/share/dotnet`; `DOTNET_ROOT` and `PATH` set in `~/.bashrc`.
- **dotnet-ef** global tool (5.0.8) installed at `~/.dotnet/tools`.
- **libssl1.1** required for .NET 5.0 on Ubuntu 24.04 (OpenSSL 3.x ships by default; .NET 5.0 needs 1.1).
- **MySQL 8.0** installed via apt. Root password: `root` (matches `appsettings.json`).

### Starting MySQL
MySQL does not auto-start via systemd in this container. Start it manually:
```bash
sudo mkdir -p /var/run/mysqld && sudo chown mysql:mysql /var/run/mysqld
sudo mysqld_safe &
sleep 3
sudo chmod 755 /var/run/mysqld
```

### Running the application
```bash
cd /workspace/MarvelComicsStore
ASPNETCORE_ENVIRONMENT=Development ASPNETCORE_URLS="http://localhost:5000" dotnet run
```
Swagger UI: `https://localhost:5001/swagger/index.html` (self-signed cert, use `-k` with curl).

The app uses `UseHttpsRedirection()`, so HTTP requests on port 5000 redirect to HTTPS on port 5001. Use `ASPNETCORE_URLS="http://localhost:5000"` to bind HTTP, then access via HTTPS at port 5001, or use `curl -Lk` to follow redirects.

### Database migrations
```bash
dotnet ef database update --project MarvelComicsStore.Infrastructure.Data --startup-project MarvelComicsStore
```

### Build and restore
```bash
dotnet restore MarvelComicsStore.WebApi.sln
dotnet build MarvelComicsStore.WebApi.sln
```

### Key gotchas
- The `/api/Comics` endpoint calls the external Marvel API (`gateway.marvel.com`). This may fail in sandboxed environments without outbound internet. The Checkout CRUD endpoints are fully local (MySQL).
- The project has no automated test suite.
- The project has no linter configuration.
- Pre-existing build warnings about `Microsoft.EntityFrameworkCore.Relational` version conflicts are benign.
