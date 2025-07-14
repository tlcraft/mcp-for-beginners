<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:36:08+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "de"
}
-->
# Study Plan Generator mit Chainlit & Microsoft Learn Docs MCP

## Voraussetzungen

- Python 3.8 oder höher  
- pip (Python-Paketmanager)  
- Internetzugang, um eine Verbindung zum Microsoft Learn Docs MCP-Server herzustellen  

## Installation

1. Klone dieses Repository oder lade die Projektdateien herunter.  
2. Installiere die benötigten Abhängigkeiten:  

   ```bash
   pip install -r requirements.txt
   ```

## Verwendung

### Szenario 1: Einfache Abfrage an Docs MCP  
Ein Kommandozeilen-Client, der eine Verbindung zum Docs MCP-Server herstellt, eine Anfrage sendet und das Ergebnis ausgibt.

1. Führe das Skript aus:  
   ```bash
   python scenario1.py
   ```  
2. Gib deine Dokumentationsfrage an der Eingabeaufforderung ein.

### Szenario 2: Study Plan Generator (Chainlit Web App)  
Eine webbasierte Oberfläche (mit Chainlit), die es Nutzern ermöglicht, einen personalisierten, wöchentlichen Lernplan für jedes technische Thema zu erstellen.

1. Starte die Chainlit-App:  
   ```bash
   chainlit run scenario2.py
   ```  
2. Öffne die lokale URL, die im Terminal angezeigt wird (z. B. http://localhost:8000), in deinem Browser.  
3. Gib im Chatfenster dein Lernthema und die Anzahl der Wochen ein, die du lernen möchtest (z. B. „AI-900 Zertifizierung, 8 Wochen“).  
4. Die App antwortet mit einem wöchentlichen Lernplan inklusive Links zu relevanten Microsoft Learn-Dokumentationen.

**Erforderliche Umgebungsvariablen:**  

Um Szenario 2 (die Chainlit-Web-App mit Azure OpenAI) zu nutzen, musst du folgende Umgebungsvariablen in einer `.env`-Datei im `python`-Verzeichnis setzen:  

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Fülle diese Werte mit deinen Azure OpenAI-Ressourcendaten aus, bevor du die App startest.

> **Tipp:** Du kannst deine eigenen Modelle ganz einfach mit [Azure AI Foundry](https://ai.azure.com/) bereitstellen.

### Szenario 3: In-Editor Docs mit MCP-Server in VS Code

Anstatt ständig zwischen Browser-Tabs zu wechseln, um Dokumentationen zu suchen, kannst du Microsoft Learn Docs direkt in VS Code mit dem MCP-Server integrieren. So kannst du:  
- Dokumentationen direkt in VS Code durchsuchen und lesen, ohne die Entwicklungsumgebung zu verlassen.  
- Dokumentationsverweise und Links direkt in deine README- oder Kursdateien einfügen.  
- GitHub Copilot und MCP zusammen nutzen für einen nahtlosen, KI-gestützten Dokumentationsworkflow.

**Beispielanwendungen:**  
- Schnell Referenzlinks in eine README einfügen, während du eine Kurs- oder Projektdokumentation schreibst.  
- Copilot zum Generieren von Code verwenden und MCP, um relevante Dokumentation sofort zu finden und zu zitieren.  
- Im Editor fokussiert bleiben und die Produktivität steigern.

> [!IMPORTANT]  
> Stelle sicher, dass du eine gültige [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) Konfiguration in deinem Workspace hast (Pfad: `.vscode/mcp.json`).

## Warum Chainlit für Szenario 2?

Chainlit ist ein modernes Open-Source-Framework zum Erstellen von konversationellen Webanwendungen. Es erleichtert die Entwicklung von chatbasierten Benutzeroberflächen, die mit Backend-Diensten wie dem Microsoft Learn Docs MCP-Server verbunden sind. Dieses Projekt nutzt Chainlit, um eine einfache, interaktive Möglichkeit zu bieten, personalisierte Lernpläne in Echtzeit zu erstellen. Mit Chainlit kannst du schnell chatbasierte Tools entwickeln und bereitstellen, die Produktivität und Lernen verbessern.

## Was diese App macht

Diese App ermöglicht es Nutzern, einen personalisierten Lernplan zu erstellen, indem sie einfach ein Thema und eine Dauer eingeben. Die App analysiert deine Eingabe, fragt den Microsoft Learn Docs MCP-Server nach relevanten Inhalten ab und organisiert die Ergebnisse in einem strukturierten, wöchentlichen Plan. Die Empfehlungen für jede Woche werden im Chat angezeigt, sodass du deinen Fortschritt leicht verfolgen kannst. Die Integration stellt sicher, dass du stets die aktuellsten und relevantesten Lernressourcen erhältst.

## Beispielanfragen

Probiere diese Anfragen im Chatfenster aus, um zu sehen, wie die App reagiert:

- `AI-900 certification, 8 weeks`  
- `Learn Azure Functions, 4 weeks`  
- `Azure DevOps, 6 weeks`  
- `Data engineering on Azure, 10 weeks`  
- `Microsoft security fundamentals, 5 weeks`  
- `Power Platform, 7 weeks`  
- `Azure AI services, 12 weeks`  
- `Cloud architecture, 9 weeks`

Diese Beispiele zeigen die Flexibilität der App für unterschiedliche Lernziele und Zeiträume.

## Referenzen

- [Chainlit Documentation](https://docs.chainlit.io/)  
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.