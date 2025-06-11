<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:32:41+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "cs"
}
-->
# Calculator LLM Client

Eine C#-Anwendung, die zeigt, wie man LangChain4j verwendet, um eine Verbindung zu einem MCP (Model Context Protocol) Calculator-Service mit GitHub Models Integration herzustellen.

## Voraussetzungen

- .NET 7 oder höher
- Ein GitHub-Konto mit Zugriff auf GitHub Models
- Ein laufender MCP Calculator-Service auf `http://localhost:8080`

## GitHub-Token erhalten

Diese Anwendung nutzt GitHub Models, wofür ein persönlicher GitHub-Zugangstoken erforderlich ist. Gehen Sie dazu wie folgt vor:

### 1. Zugriff auf GitHub Models
1. Gehen Sie zu [GitHub Models](https://github.com/marketplace/models)
2. Melden Sie sich mit Ihrem GitHub-Konto an
3. Beantragen Sie den Zugriff auf GitHub Models, falls noch nicht geschehen

### 2. Persönlichen Zugriffstoken erstellen
1. Gehen Sie zu [GitHub Einstellungen → Entwickler-Einstellungen → Persönliche Zugriffstoken → Tokens (klassisch)](https://github.com/settings/tokens)
2. Klicken Sie auf "Neuen Token generieren" → "Neuen Token generieren (klassisch)"
3. Vergeben Sie einen aussagekräftigen Namen für den Token (z.B. "MCP Calculator Client")
4. Legen Sie die Ablaufzeit fest
5. Wählen Sie folgende Berechtigungen aus:
   - `repo` (falls Zugriff auf private Repositories nötig ist)
   - `user:email`
6. Klicken Sie auf "Token generieren"
7. **Wichtig**: Kopieren Sie den Token sofort – er ist später nicht mehr sichtbar!

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

1. **Projekt klonen oder ins Projektverzeichnis wechseln**

2. **Abhängigkeiten installieren**:
   ```cmd
   mvnw clean install
   ```
   Oder, wenn Maven global installiert ist:
   ```cmd
   mvn clean install
   ```

3. **Umgebungsvariable setzen** (siehe Abschnitt "GitHub-Token erhalten")

4. **MCP Calculator Service starten**:
   Stellen Sie sicher, dass der MCP Calculator Service aus Kapitel 1 auf `http://localhost:8080/sse` läuft. Dieser muss vor dem Start des Clients aktiv sein.

## Anwendung ausführen

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Was die Anwendung macht

Die Anwendung demonstriert drei Hauptinteraktionen mit dem Calculator-Service:

1. **Addition**: Berechnet die Summe von 24,5 und 17,3
2. **Quadratwurzel**: Berechnet die Quadratwurzel von 144
3. **Hilfe**: Zeigt verfügbare Calculator-Funktionen an

## Erwartete Ausgabe

Bei erfolgreichem Lauf sollte die Ausgabe etwa so aussehen:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Fehlerbehebung

### Häufige Probleme

1. **"GITHUB_TOKEN environment variable not set"**
   - Stellen Sie sicher, dass die Umgebungsvariable `GITHUB_TOKEN` gesetzt ist

### Debugging

Um Debug-Logging zu aktivieren, fügen Sie beim Starten der Anwendung folgendes JVM-Argument hinzu:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfiguration

Die Anwendung ist so konfiguriert, dass sie:
- GitHub Models mit `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse` verwendet
- Eine Timeout-Zeit von 60 Sekunden für Anfragen nutzt
- Request- und Response-Logging zur Fehleranalyse aktiviert

## Abhängigkeiten

Wichtige Abhängigkeiten in diesem Projekt:
- **LangChain4j**: Für KI-Integration und Tool-Management
- **LangChain4j MCP**: Für Model Context Protocol Unterstützung
- **LangChain4j GitHub Models**: Für GitHub Models Integration
- **Spring Boot**: Für Anwendungsframework und Dependency Injection

## Lizenz

Dieses Projekt steht unter der Apache License 2.0 - siehe die [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) Datei für Details.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědni za jakékoli nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.