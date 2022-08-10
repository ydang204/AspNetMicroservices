compose-override-up:
	docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

compose-override-down:
	docker-compose -f docker-compose.yml -f docker-compose.override.yml down

mongo-db:
	docker run -d -p 27017:27017 --name shopping-mongo mongo

.PHONY: run-dev, mongo-db