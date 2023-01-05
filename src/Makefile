compose-up:
	docker-compose -f docker-compose.yml -f docker-compose.$(env).yml up -d 

compose-build-up:
	docker-compose -f docker-compose.yml -f docker-compose.$(env).yml up -d --no-deps --build $(service)

compose-down:
	docker-compose -f docker-compose.yml -f docker-compose.$(env).yml down

mongo:
	docker run -d -p 27017:27017 --name shopping-mongo mongo

mongo-client:
	docker run -d -p 3000:3000 mongoclient/mongoclient

redis:
	docker run -d -p 6739:6739 --name redis redis

postgres:
	docker run -d -p 5432:5432 --name postgres -e POSTGRES_PASSWORD=admin1234 postgres

.PHONY: compose-up, compose-build-up, compose-down, mongo-db, redis, mongo, mongo-client, postgres