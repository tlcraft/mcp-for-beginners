<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:19:52+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "de"
}
-->
# Fallstudie: REST-API in API Management als MCP-Server bereitstellen

Azure API Management ist ein Dienst, der ein Gateway über Ihren API-Endpunkten bereitstellt. Azure API Management fungiert dabei als Proxy vor Ihren APIs und kann entscheiden, wie mit eingehenden Anfragen verfahren wird.

Durch die Nutzung erhalten Sie eine Vielzahl von Funktionen wie:

- **Sicherheit**: Sie können alles von API-Schlüsseln, JWT bis hin zu Managed Identity verwenden.
- **Ratenbegrenzung**: Eine großartige Funktion, mit der Sie festlegen können, wie viele Aufrufe pro Zeiteinheit zugelassen werden. Das sorgt dafür, dass alle Nutzer eine gute Erfahrung machen und Ihr Dienst nicht mit Anfragen überlastet wird.
- **Skalierung & Lastverteilung**: Sie können mehrere Endpunkte einrichten, um die Last zu verteilen, und auch entscheiden, wie die Lastverteilung erfolgen soll.
- **KI-Funktionen wie semantisches Caching**, Token-Limits, Token-Überwachung und mehr. Diese Funktionen verbessern die Reaktionsfähigkeit und helfen Ihnen, Ihre Token-Ausgaben im Blick zu behalten. [Hier mehr lesen](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Warum MCP + Azure API Management?

Das Model Context Protocol wird schnell zum Standard für agentenbasierte KI-Anwendungen und wie man Tools und Daten konsistent bereitstellt. Azure API Management ist die natürliche Wahl, wenn Sie APIs „verwalten“ müssen. MCP-Server integrieren sich oft mit anderen APIs, um beispielsweise Anfragen an ein Tool weiterzuleiten. Daher macht die Kombination von Azure API Management und MCP viel Sinn.

## Überblick

In diesem speziellen Anwendungsfall lernen wir, wie man API-Endpunkte als MCP-Server bereitstellt. Dadurch können wir diese Endpunkte einfach in eine agentenbasierte App integrieren und gleichzeitig die Funktionen von Azure API Management nutzen.

## Hauptfunktionen

- Sie wählen die Endpunkt-Methoden aus, die Sie als Tools bereitstellen möchten.
- Die zusätzlichen Funktionen hängen davon ab, was Sie im Policy-Bereich für Ihre API konfigurieren. Hier zeigen wir, wie Sie Ratenbegrenzung hinzufügen können.

## Vorbereitung: API importieren

Wenn Sie bereits eine API in Azure API Management haben, können Sie diesen Schritt überspringen. Falls nicht, schauen Sie sich diesen Link an: [API in Azure API Management importieren](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## API als MCP-Server bereitstellen

Um die API-Endpunkte bereitzustellen, gehen Sie wie folgt vor:

1. Navigieren Sie zum Azure-Portal unter <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   Gehen Sie zu Ihrer API Management-Instanz.

1. Wählen Sie im linken Menü APIs > MCP Servers > + Create new MCP Server.

1. Wählen Sie unter API eine REST-API aus, die Sie als MCP-Server bereitstellen möchten.

1. Wählen Sie eine oder mehrere API-Operationen aus, die als Tools bereitgestellt werden sollen. Sie können alle oder nur bestimmte Operationen auswählen.

    ![Methoden zum Bereitstellen auswählen](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Klicken Sie auf **Create**.

1. Navigieren Sie zu den Menüpunkten **APIs** und **MCP Servers**, dort sollten Sie Folgendes sehen:

    ![MCP-Server im Hauptbereich anzeigen](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    Der MCP-Server wurde erstellt und die API-Operationen werden als Tools bereitgestellt. Der MCP-Server wird im MCP Servers-Bereich aufgelistet. Die Spalte URL zeigt den Endpunkt des MCP-Servers, den Sie zum Testen oder in einer Client-Anwendung aufrufen können.

## Optional: Richtlinien konfigurieren

Azure API Management basiert auf dem Konzept von Richtlinien, mit denen Sie verschiedene Regeln für Ihre Endpunkte festlegen können, z. B. Ratenbegrenzung oder semantisches Caching. Diese Richtlinien werden in XML verfasst.

So richten Sie eine Richtlinie zur Ratenbegrenzung Ihres MCP-Servers ein:

1. Wählen Sie im Portal unter APIs **MCP Servers** aus.

1. Wählen Sie den erstellten MCP-Server aus.

1. Wählen Sie im linken Menü unter MCP **Policies**.

1. Fügen Sie im Richtlinien-Editor die gewünschten Richtlinien hinzu oder bearbeiten Sie diese. Die Richtlinien sind im XML-Format definiert. Zum Beispiel können Sie eine Richtlinie hinzufügen, die die Aufrufe der MCP-Server-Tools begrenzt (in diesem Beispiel 5 Aufrufe pro 30 Sekunden pro Client-IP-Adresse). Hier ist das XML, das die Ratenbegrenzung bewirkt:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    So sieht der Richtlinien-Editor aus:

    ![Richtlinien-Editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Ausprobieren

Lassen Sie uns sicherstellen, dass unser MCP-Server wie gewünscht funktioniert.

Dazu verwenden wir Visual Studio Code und GitHub Copilot im Agent-Modus. Wir fügen den MCP-Server zu einer *mcp.json* Datei hinzu. Dadurch agiert Visual Studio Code als Client mit agentenbasierten Fähigkeiten, und Endbenutzer können eine Eingabeaufforderung eingeben und mit dem Server interagieren.

So fügen Sie den MCP-Server in Visual Studio Code hinzu:

1. Verwenden Sie den MCP-Befehl **Add Server** aus der Befehls-Palette.

1. Wählen Sie bei der Aufforderung den Servertyp: **HTTP (HTTP oder Server Sent Events)**.

1. Geben Sie die URL des MCP-Servers in API Management ein. Beispiel: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (für SSE-Endpunkt) oder **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (für MCP-Endpunkt). Beachten Sie den Unterschied bei den Transportarten: `/sse` oder `/mcp`.

1. Geben Sie eine Server-ID Ihrer Wahl ein. Dieser Wert ist nicht kritisch, hilft Ihnen aber, die Serverinstanz zu identifizieren.

1. Wählen Sie, ob die Konfiguration in den Workspace-Einstellungen oder den Benutzereinstellungen gespeichert werden soll.

  - **Workspace-Einstellungen** – Die Serverkonfiguration wird in einer .vscode/mcp.json-Datei gespeichert, die nur im aktuellen Workspace verfügbar ist.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    Oder wenn Sie Streaming HTTP als Transport wählen, sieht es etwas anders aus:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Benutzereinstellungen** – Die Serverkonfiguration wird in der globalen *settings.json* Datei gespeichert und ist in allen Workspaces verfügbar. Die Konfiguration sieht ungefähr so aus:

    ![Benutzereinstellung](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Sie müssen außerdem eine Konfiguration hinzufügen, einen Header, damit die Authentifizierung gegenüber Azure API Management korrekt funktioniert. Es wird ein Header namens **Ocp-Apim-Subscription-Key** verwendet.

    - So fügen Sie ihn in den Einstellungen hinzu:

    ![Header für Authentifizierung hinzufügen](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png)  
      Dadurch wird eine Eingabeaufforderung angezeigt, in der Sie den API-Schlüssel eingeben können, den Sie im Azure-Portal für Ihre Azure API Management-Instanz finden.

    - Um ihn stattdessen in *mcp.json* hinzuzufügen, können Sie es so machen:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Agent-Modus verwenden

Jetzt sind wir sowohl in den Einstellungen als auch in *.vscode/mcp.json* eingerichtet. Probieren wir es aus.

Es sollte ein Tools-Symbol geben, das so aussieht, wo die vom Server bereitgestellten Tools aufgelistet sind:

![Tools vom Server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Klicken Sie auf das Tools-Symbol, und Sie sollten eine Liste der Tools sehen:

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Geben Sie eine Eingabeaufforderung im Chat ein, um das Tool aufzurufen. Wenn Sie beispielsweise ein Tool ausgewählt haben, das Informationen zu einer Bestellung abruft, können Sie den Agenten nach einer Bestellung fragen. Hier ein Beispiel für eine Eingabeaufforderung:

    ```text
    get information from order 2
    ```

    Ihnen wird nun ein Tools-Symbol angezeigt, das Sie auffordert, das Tool auszuführen. Wählen Sie, um das Tool weiter auszuführen. Sie sollten nun eine Ausgabe wie diese sehen:

    ![Ergebnis der Eingabeaufforderung](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **Was Sie sehen, hängt von den eingerichteten Tools ab, aber die Idee ist, dass Sie eine textuelle Antwort wie oben erhalten.**


## Verweise

So können Sie mehr erfahren:

- [Tutorial zu Azure API Management und MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python-Beispiel: Sichere Remote-MCP-Server mit Azure API Management (experimentell)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP-Client-Autorisierungslabor](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Verwenden Sie die Azure API Management-Erweiterung für VS Code zum Importieren und Verwalten von APIs](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Registrieren und Entdecken von Remote-MCP-Servern im Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Tolles Repository, das viele KI-Funktionen mit Azure API Management zeigt
- [AI Gateway Workshops](https://azure-samples.github.io/AI-Gateway/) Enthält Workshops mit dem Azure-Portal, eine großartige Möglichkeit, KI-Funktionen zu evaluieren.

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.