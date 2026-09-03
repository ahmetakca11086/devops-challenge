#!/bin/bash

set -e

echo "🚀 Deploying to Kubernetes..."

echo "📦 Applying manifests..."
kubectl apply -f k8s/

echo "🔄 Restarting deployments..."
kubectl rollout restart deployment hello-team-api
kubectl rollout restart deployment webapp

echo "⏳ Waiting for rollout..."
kubectl rollout status deployment hello-team-api
kubectl rollout status deployment webapp

echo "Deployment complete!"
