<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:33:02+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "sl"
}
-->
# Deploying MCP Servers

Deploying your MCP server lets others access its tools and resources beyond your local setup. There are several deployment options depending on your needs for scalability, reliability, and ease of management. Below you'll find guidance for deploying MCP servers locally, in containers, and on the cloud.

## Overview

This lesson explains how to deploy your MCP Server app.

## Learning Objectives

By the end of this lesson, you will be able to:

- Compare different deployment methods.
- Deploy your app.

## Local development and deployment

If your server is intended to run on users' machines, you can follow these steps:

1. **Download the server**. If you didn’t create the server, download it first to your machine.  
1. **Start the server process**: Run your MCP server application.

For SSE (not required for stdio type server):

1. **Configure networking**: Make sure the server is accessible on the expected port.  
1. **Connect clients**: Use local connection URLs like `http://localhost:3000`.

## Cloud Deployment

MCP servers can be deployed to various cloud platforms:

- **Serverless Functions**: Deploy lightweight MCP servers as serverless functions.  
- **Container Services**: Use services like Azure Container Apps, AWS ECS, or Google Cloud Run.  
- **Kubernetes**: Deploy and manage MCP servers in Kubernetes clusters for high availability.

### Example: Azure Container Apps

Azure Container Apps support deploying MCP Servers. It’s still evolving and currently supports SSE servers.

Here’s how to do it:

1. Clone a repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Run it locally to test:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. To test locally, create a *mcp.json* file in a *.vscode* folder and add the following content:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  After starting the SSE server, you can click the play icon in the JSON file. You should now see tools on the server recognized by GitHub Copilot, indicated by the Tool icon.

1. To deploy, run this command:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

That’s it—deploy locally or to Azure following these steps.

## Additional Resources

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)  
- [Azure Container Apps article](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)  
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)  

## What's Next

- Next: [Practical Implementation](/04-PracticalImplementation/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v izvorni jezik velja za avtoritativni vir. Za ključne informacije priporočamo strokovni prevod, opravljen s strani človeka. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne prevzemamo odgovornosti.