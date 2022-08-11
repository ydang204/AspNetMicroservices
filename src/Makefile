remove-images:
	docker rmi $(docker images -q)

stop-containers:
	docker stop $(docker ps -aq)

remove-containers:
	docker rm $(docker ps -aq)

compose-override-up:
	docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

compose-override-down:
	docker-compose -f docker-compose.yml -f docker-compose.override.yml down

mongo-db:
	docker run -d -p 27017:27017 --name shopping-mongo mongo

mongo-client:
	docker run -d -p 3000:3000 mongoclient/mongoclient

.PHONY: run-dev, mongo-db, remove-containers, remove-images, stop-containers