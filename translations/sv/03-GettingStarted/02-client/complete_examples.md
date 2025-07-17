<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T09:10:21+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "sv"
}
-->
# Kompletta MCP-klientexempel

Den här katalogen innehåller kompletta, fungerande exempel på MCP-klienter i olika programmeringsspråk. Varje klient visar hela funktionaliteten som beskrivs i huvudtutorialen i README.md.

## Tillgängliga klienter

### 1. Java-klient (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) över HTTP
- **Målserver**: `http://localhost:8080`
- **Funktioner**: 
  - Upprättande av anslutning och ping
  - Lista verktyg
  - Kalkylatoroperationer (addera, subtrahera, multiplicera, dividera, hjälp)
  - Felhantering och resultatutvinning

**För att köra:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C#-klient (`client_example_csharp.cs`)
- **Transport**: Stdio (Standard Input/Output)
- **Målserver**: Lokal .NET MCP-server via dotnet run
- **Funktioner**:
  - Automatisk serverstart via stdio-transport
  - Lista verktyg och resurser
  - Kalkylatoroperationer
  - JSON-resultatparsing
  - Omfattande felhantering

**För att köra:**
```bash
dotnet run
```

### 3. TypeScript-klient (`client_example_typescript.ts`)
- **Transport**: Stdio (Standard Input/Output)
- **Målserver**: Lokal Node.js MCP-server
- **Funktioner**:
  - Fullt stöd för MCP-protokollet
  - Verktygs-, resurs- och promptoperationer
  - Kalkylatoroperationer
  - Läsning av resurser och körning av prompts
  - Robust felhantering

**För att köra:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python-klient (`client_example_python.py`)
- **Transport**: Stdio (Standard Input/Output)  
- **Målserver**: Lokal Python MCP-server
- **Funktioner**:
  - Async/await-mönster för operationer
  - Upptäckt av verktyg och resurser
  - Testning av kalkylatoroperationer
  - Läsning av resursinnehåll
  - Klassbaserad struktur

**För att köra:**
```bash
python client_example_python.py
```

## Vanliga funktioner i alla klienter

Varje klientimplementation visar:

1. **Anslutningshantering**
   - Upprätta anslutning till MCP-servern
   - Hantera anslutningsfel
   - Korrekt städning och resursförvaltning

2. **Serverupptäckt**
   - Lista tillgängliga verktyg
   - Lista tillgängliga resurser (där det stöds)
   - Lista tillgängliga prompts (där det stöds)

3. **Verktygsanrop**
   - Grundläggande kalkylatoroperationer (addera, subtrahera, multiplicera, dividera)
   - Hjälpkommandon för serverinformation
   - Korrekt argumentöverföring och resultatbehandling

4. **Felhantering**
   - Anslutningsfel
   - Fel vid verktygsexekvering
   - Smidig hantering av fel och användarfeedback

5. **Resultatbearbetning**
   - Extrahera textinnehåll från svar
   - Formatera utdata för läsbarhet
   - Hantera olika svarformat

## Förutsättningar

Innan du kör dessa klienter, se till att du har:

1. **Den motsvarande MCP-servern igång** (från `../01-first-server/`)
2. **Nödvändiga beroenden installerade** för ditt valda språk
3. **Korrekt nätverksanslutning** (för HTTP-baserade transporter)

## Viktiga skillnader mellan implementationer

| Språk      | Transport | Serverstart   | Async-modell | Viktiga bibliotek |
|------------|-----------|---------------|--------------|-------------------|
| Java       | SSE/HTTP  | Extern        | Synkron      | WebFlux, MCP SDK  |
| C#         | Stdio     | Automatisk    | Async/Await  | .NET MCP SDK      |
| TypeScript | Stdio     | Automatisk    | Async/Await  | Node MCP SDK      |
| Python     | Stdio     | Automatisk    | AsyncIO      | Python MCP SDK    |

## Nästa steg

Efter att ha utforskat dessa klientexempel:

1. **Modifiera klienterna** för att lägga till nya funktioner eller operationer
2. **Skapa din egen server** och testa den med dessa klienter
3. **Experimentera med olika transporter** (SSE vs. Stdio)
4. **Bygg en mer komplex applikation** som integrerar MCP-funktionalitet

## Felsökning

### Vanliga problem

1. **Anslutning nekad**: Kontrollera att MCP-servern körs på förväntad port/sökväg
2. **Modul saknas**: Installera nödvändigt MCP SDK för ditt språk
3. **Behörighet nekad**: Kontrollera filbehörigheter för stdio-transport
4. **Verktyg saknas**: Verifiera att servern implementerar förväntade verktyg

### Tips för felsökning

1. **Aktivera detaljerad loggning** i ditt MCP SDK
2. **Granska serverloggar** för felmeddelanden
3. **Verifiera att verktygsnamn och signaturer** stämmer mellan klient och server
4. **Testa först med MCP Inspector** för att validera serverfunktionalitet

## Relaterad dokumentation

- [Huvudtutorial för klient](./README.md)
- [MCP-serverexempel](../../../../03-GettingStarted/01-first-server)
- [MCP med LLM-integration](../../../../03-GettingStarted/03-llm-client)
- [Officiell MCP-dokumentation](https://modelcontextprotocol.io/)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.