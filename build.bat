docker build -t identitydemo . 
docker image prune --force --filter label=stage=build-env
docker image prune --force --filter dangling=true
docker save identitydemo > identitydemo.tar