#!/usr/bin/env bash
# deploy-containerapp.sh
# ---------------------------------------------
# Deploy the calculator sample to Azure Container Apps
# ---------------------------------------------
set -euo pipefail

# ==== CONFIGURABLE VARIABLES ====
SUBSCRIPTION_ID="<your‑subscription‑id>"
LOCATION="westeurope"               # any ACA‑supported region
RESOURCE_GROUP="rg-contentsafety"
ENV_NAME="env-contentsafety"
APP_NAME="calculator-app"
GITHUB_REPO="https://github.com/roryp/contentsafety"
GIT_BRANCH="main"                   # change if you deploy a branch
CONTEXT_PATH="calculator"           # sub‑folder holding Dockerfile / code
TARGET_PORT=8080                    # update if your Dockerfile EXPOSEs a different port
# =================================

echo "🔐  Azure login (skip if already logged in)…"
az login --only-show-errors >/dev/null
az account set --subscription "$SUBSCRIPTION_ID"

echo "📦  Ensuring Container Apps CLI extension is present…"
az extension add --name containerapp --upgrade --allow-preview -y

echo "🛠️  Registering required resource providers (one‑time)…"
az provider register --namespace Microsoft.App              --wait
az provider register --namespace Microsoft.OperationalInsights --wait

echo "📁  Creating (or re‑using) resource group '$RESOURCE_GROUP'…"
az group create \
  --name "$RESOURCE_GROUP" \
  --location "$LOCATION" \
  --output none

echo "🌳  Creating (or re‑using) Container Apps environment '$ENV_NAME'…"
az containerapp env create \
  --name "$ENV_NAME" \
  --resource-group "$RESOURCE_GROUP" \
  --location "$LOCATION" \
  --output none

echo "🚀  Building & deploying the container app…"
az containerapp up \
  --name "$APP_NAME" \
  --repo "$GITHUB_REPO" \
  --branch "$GIT_BRANCH" \
  --context-path "$CONTEXT_PATH" \
  --ingress external \
  --target-port "$TARGET_PORT" \
  --environment "$ENV_NAME" \
  --resource-group "$RESOURCE_GROUP" \
  --location "$LOCATION" \
  --system-assigned \
  --output table

# Fetch and print the public URL
URL=$(az containerapp show -n "$APP_NAME" -g "$RESOURCE_GROUP" --query properties.configuration.ingress.fqdn -o tsv)
echo ""
echo "✅  Deployment complete! Your calculator is live at:"
echo "   https://$URL/"
