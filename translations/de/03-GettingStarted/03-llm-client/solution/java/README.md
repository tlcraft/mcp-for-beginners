<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:19:03+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "de"
}
-->
# Calculator LLM Client

Eine Java-Anwendung, die zeigt, wie man LangChain4j verwendet, um sich mit einem MCP (Model Context Protocol) Calculator-Service mit GitHub Models-Integration zu verbinden.

## Voraussetzungen

- Java 21 oder höher  
- Maven 3.6+ (oder nutze den enthaltenen Maven Wrapper)  
- Ein GitHub-Konto mit Zugriff auf GitHub Models  
- Ein laufender MCP Calculator-Service auf `http://localhost:8080`  

## GitHub Token erhalten

Diese Anwendung nutzt GitHub Models, wofür ein persönlicher GitHub-Zugangstoken erforderlich ist. Folge diesen Schritten, um deinen Token zu erhalten:

### 1. GitHub Models aufrufen  
1. Gehe zu [GitHub Models](https://github.com/marketplace/models)  
2. Melde dich mit deinem GitHub-Konto an  
3. Fordere Zugriff auf GitHub Models an, falls noch nicht geschehen  

### 2. Persönlichen Zugangstoken erstellen  
1. Gehe zu [GitHub Einstellungen → Entwickler-Einstellungen → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)  
2. Klicke auf "Generate new token" → "Generate new token (classic)"  
3. Vergib einen aussagekräftigen Namen für deinen Token (z.B. "MCP Calculator Client")  
4. Lege die Ablaufzeit nach Bedarf fest  
5. Wähle folgende Berechtigungen aus:  
   - `repo` (falls Zugriff auf private Repositories benötigt wird)  
   - `user:email`  
6. Klicke auf "Generate token"  
7. **Wichtig**: Kopiere den Token sofort – du kannst ihn später nicht mehr einsehen!  

### 3. Umgebungsvariable setzen

#### Unter Windows (Eingabeaufforderung):  
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Unter Windows (PowerShell):  
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Unter macOS/Linux:  
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Einrichtung und Installation

1. **Projekt klonen oder in das Projektverzeichnis wechseln**

2. **Abhängigkeiten installieren:**  
   ```cmd
   mvnw clean install
   ```  
   Oder, falls Maven global installiert ist:  
   ```cmd
   mvn clean install
   ```

3. **Umgebungsvariable setzen** (siehe Abschnitt „GitHub Token erhalten“ oben)

4. **MCP Calculator Service starten:**  
   Stelle sicher, dass der MCP Calculator Service aus Kapitel 1 unter `http://localhost:8080/sse` läuft. Dieser muss gestartet sein, bevor du den Client startest.

## Anwendung ausführen

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Was die Anwendung macht

Die Anwendung zeigt drei Hauptinteraktionen mit dem Calculator-Service:

1. **Addition**: Berechnet die Summe von 24,5 und 17,3  
2. **Quadratwurzel**: Berechnet die Quadratwurzel von 144  
3. **Hilfe**: Zeigt verfügbare Calculator-Funktionen  

## Erwartete Ausgabe

Bei erfolgreichem Lauf solltest du eine Ausgabe ähnlich der folgenden sehen:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Fehlerbehebung

### Häufige Probleme

1. **„GITHUB_TOKEN Umgebungsvariable nicht gesetzt“**  
   - Stelle sicher, dass du die `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean` gesetzt hast  

### Debugging

Um Debug-Logging zu aktivieren, füge beim Starten folgenden JVM-Parameter hinzu:  
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfiguration

Die Anwendung ist wie folgt konfiguriert:  
- Nutzung von GitHub Models mit `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`  
- 60 Sekunden Timeout für Anfragen  
- Aktiviertes Logging von Anfragen und Antworten für Debug-Zwecke  

## Abhängigkeiten

Wichtige Abhängigkeiten in diesem Projekt:  
- **LangChain4j**: Für KI-Integration und Tool-Management  
- **LangChain4j MCP**: Für Model Context Protocol-Unterstützung  
- **LangChain4j GitHub Models**: Für GitHub Models Integration  
- **Spring Boot**: Für Anwendungsframework und Dependency Injection  

## Lizenz

Dieses Projekt ist unter der Apache License 2.0 lizenziert – siehe die [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) Datei für Details.

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.