#!/bin/bash

set -e

SHA=$(git rev-parse HEAD)

echo "Deploying image: $SHA"

kubectl set image deployment/hello-team-api \
api=ghcr.io/ahmetakca11086/hello-team-api:$SHA

kubectl rollout status deployment/hello-team-api
