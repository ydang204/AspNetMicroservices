run-dev:
	docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

mongo-db:
	docker run -d -p 27017:27017 --name shopping-mongo mongo

.PHONY: run-dev, mongo-db