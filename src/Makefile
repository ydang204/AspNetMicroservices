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

portainer-agent:
	docker run -d -p 9001:9001 --name portainer_agent --restart=always -v /var/run/docker.sock:/var/run/docker.sock -v /var/lib/docker/volumes:/var/lib/docker/volumes portainer/agent:2.18.3

portainer-reset-password:
	docker run --rm -v src_portainer_data:/data portainer/helper-reset-password

.PHONY: compose-up, compose-build-up, compose-down, mongo-db, redis, mongo, mongo-client, postgres, portainer-agent, portainer-reset-password