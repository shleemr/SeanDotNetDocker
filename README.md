# SeanDotNetDocker

### .Net Core + Docker start project

### Build docker compose
##### Staging
```
docker-compose -f docker-compose.yml -f docker-compose.debug.yml up --build -d
```

##### Production
```
docker-compose -f docker-compose.yml -f docker-compose.prod.yml up --build -d
```
