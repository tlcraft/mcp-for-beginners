<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-16T15:00:10+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "de"
}
-->
# Bereitstellung von MCP-Servern

Die Bereitstellung Ihres MCP-Servers ermöglicht es anderen, auf dessen Werkzeuge und Ressourcen über Ihre lokale Umgebung hinaus zuzugreifen. Es gibt verschiedene Bereitstellungsstrategien, die je nach Anforderungen an Skalierbarkeit, Zuverlässigkeit und einfache Verwaltung in Betracht gezogen werden sollten. Im Folgenden finden Sie Hinweise zur lokalen Bereitstellung von MCP-Servern, in Containern und in der Cloud.

## Überblick

Diese Lektion behandelt, wie Sie Ihre MCP Server-App bereitstellen.

## Lernziele

Am Ende dieser Lektion werden Sie in der Lage sein:

- Verschiedene Bereitstellungsansätze zu bewerten.
- Ihre App bereitzustellen.

## Lokale Entwicklung und Bereitstellung

Wenn Ihr Server auf den Rechnern der Nutzer laufen soll, können Sie folgende Schritte befolgen:

1. **Server herunterladen**. Falls Sie den Server nicht selbst geschrieben haben, laden Sie ihn zuerst auf Ihren Rechner herunter.  
1. **Serverprozess starten**: Führen Sie Ihre MCP Server-Anwendung aus.

Für SSE (nicht erforderlich für stdio-Server)

1. **Netzwerk konfigurieren**: Stellen Sie sicher, dass der Server auf dem erwarteten Port erreichbar ist.  
1. **Clients verbinden**: Verwenden Sie lokale Verbindungs-URLs wie `http://localhost:3000`.

## Cloud-Bereitstellung

MCP-Server können auf verschiedenen Cloud-Plattformen bereitgestellt werden:

- **Serverless Functions**: Leichte MCP-Server als serverlose Funktionen bereitstellen  
- **Container-Services**: Dienste wie Azure Container Apps, AWS ECS oder Google Cloud Run nutzen  
- **Kubernetes**: MCP-Server in Kubernetes-Clustern für hohe Verfügbarkeit bereitstellen und verwalten

### Beispiel: Azure Container Apps

Azure Container Apps unterstützen die Bereitstellung von MCP-Servern. Das Projekt ist noch in Arbeit und unterstützt derzeit SSE-Server.

So gehen Sie vor:

1. Klonen Sie ein Repository:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Führen Sie es lokal aus, um alles zu testen:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Um es lokal auszuprobieren, erstellen Sie eine *mcp.json*-Datei in einem *.vscode*-Verzeichnis und fügen Sie folgenden Inhalt hinzu:

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

  Sobald der SSE-Server gestartet ist, können Sie im JSON-File auf das Wiedergabesymbol klicken. Die Werkzeuge auf dem Server sollten nun von GitHub Copilot erkannt werden, siehe das Werkzeug-Symbol.

1. Zum Bereitstellen führen Sie den folgenden Befehl aus:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

So einfach ist das: lokal bereitstellen oder über diese Schritte in Azure.

## Zusätzliche Ressourcen

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)  
- [Azure Container Apps Artikel](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)  
- [Azure Container Apps MCP Repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Was kommt als Nächstes

- Weiter zu: [Praktische Umsetzung](/04-PracticalImplementation/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ausgangssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.