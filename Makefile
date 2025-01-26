# Variables
STARTUP_PROJECT = ECM.Api
INFRASTRUCTURE_PROJECT = ECM.Infrastructure
MIGRATION_NAME ?= InitialMigration

# Docker commands
.PHONY: docker-up
docker-up:
	docker-compose up -d

.PHONY: docker-down
docker-down:
	docker-compose down

.PHONY: docker-logs
docker-logs:
	docker-compose logs -f

# Database migration commands
.PHONY: add-migration
add-migration:
	cd $(STARTUP_PROJECT) && dotnet ef migrations add $(MIGRATION_NAME) --project ../$(INFRASTRUCTURE_PROJECT) --startup-project .

.PHONY: remove-migration
remove-migration:
	cd $(STARTUP_PROJECT) && dotnet ef migrations remove --project ../$(INFRASTRUCTURE_PROJECT) --startup-project .

.PHONY: update-database
update-database:
	cd $(STARTUP_PROJECT) && dotnet ef database update --project ../$(INFRASTRUCTURE_PROJECT) --startup-project .

# Development commands
.PHONY: build
build:
	dotnet build

.PHONY: run
run:
	cd $(STARTUP_PROJECT) && dotnet run

.PHONY: clean
clean:
	dotnet clean
	find . -name "bin" -type d -exec rm -rf {} +
	find . -name "obj" -type d -exec rm -rf {} +

# Install tools
.PHONY: install-tools
install-tools:
	dotnet tool install --global dotnet-ef