# microservices
Create an app using microservice architecture.

# Platform Service - Microservice for software management

Platform Service is a microservice with RESTFul web apis for adding and viewing platform/software information.

- Implemented using ASP.Net core web api project.
- Added docker file to create dcoker image of Platfrom Service
- Published the docker image to docker hub - devithavamani/platform_svc
- Created PlatformService deployment yaml file to deploy the service in k8s cluster.
  The deployment file uses the publish docker image for running container within the POD.
    Link: k8s\platformsvc-depl.yaml
- Created NodePort Service to expose the platform service to the external users.
    Link: k8s\platformsvc-nodeport-depl.yaml

