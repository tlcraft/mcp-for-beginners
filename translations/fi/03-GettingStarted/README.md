<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:37:06+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "fi"
}
-->
## Aloittaminen  

Tässä osiossa on useita oppitunteja:

- **-1- Ensimmäinen palvelimesi**, tässä ensimmäisessä oppitunnissa opit luomaan ensimmäisen palvelimesi ja tarkastelemaan sitä inspector-työkalulla, arvokas tapa testata ja virheenkorjata palvelinta, [oppitunnille](/03-GettingStarted/01-first-server/README.md)

- **-2- Asiakas**, tässä oppitunnissa opit kirjoittamaan asiakkaan, joka voi yhdistää palvelimeesi, [oppitunnille](/03-GettingStarted/02-client/README.md)

- **-3- Asiakas LLM:n kanssa**, vielä parempi tapa kirjoittaa asiakas on lisätä siihen LLM, jotta se voi "neuvotella" palvelimesi kanssa siitä, mitä tehdä, [oppitunnille](/03-GettingStarted/03-llm-client/README.md)

- **-4- Palvelimen käyttäminen GitHub Copilot Agent -tilassa Visual Studio Codessa**. Tässä tarkastelemme MCP-palvelimen ajamista Visual Studio Coden sisällä, [oppitunnille](/03-GettingStarted/04-vscode/README.md)

- **-5- Kulutus SSE:n (Server Sent Events) kautta** SSE on standardi palvelimelta asiakkaalle tapahtuvaan suoratoistoon, joka mahdollistaa palvelimien työntää reaaliaikaisia päivityksiä asiakkaille HTTP:n yli [oppitunnille](/03-GettingStarted/05-sse-server/README.md)

- **-6- AI Toolkitin hyödyntäminen VSCodea varten** MCP-asiakkaiden ja -palvelimien kuluttamiseen ja testaamiseen [oppitunnille](/03-GettingStarted/06-aitk/README.md)

- **-7 Testaus**. Tässä keskitymme erityisesti siihen, miten voimme testata palvelintamme ja asiakastamme eri tavoin, [oppitunnille](/03-GettingStarted/07-testing/README.md)

- **-8- Julkaisu**. Tämä luku käsittelee erilaisia tapoja julkaista MCP-ratkaisujasi, [oppitunnille](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) on avoin protokolla, joka standardisoi sen, miten sovellukset tarjoavat kontekstia LLM:ille. Ajattele MCP:tä kuin USB-C-porttina tekoälysovelluksille – se tarjoaa standardoidun tavan yhdistää tekoälymalleja erilaisiin tietolähteisiin ja työkaluihin.

## Oppimistavoitteet

Tämän oppitunnin jälkeen osaat:

- Määrittää MCP-kehitysympäristöt C#:lle, Javalle, Pythonille, TypeScriptille ja JavaScriptille
- Rakentaa ja ottaa käyttöön perus MCP-palvelimia mukautetuilla ominaisuuksilla (resurssit, kehotteet ja työkalut)
- Luoda isäntäsovelluksia, jotka yhdistävät MCP-palvelimiin
- Testata ja virheenkorjata MCP-toteutuksia
- Ymmärtää yleisiä asennushaasteita ja niiden ratkaisuja
- Yhdistää MCP-toteutuksesi suosittuihin LLM-palveluihin

## MCP-ympäristön määrittäminen

Ennen kuin aloitat MCP:n parissa työskentelyn, on tärkeää valmistella kehitysympäristö ja ymmärtää perus työnkulku. Tämä osio opastaa sinua alkuasetuksissa sujuvan MCP-käynnistyksen varmistamiseksi.

### Esivaatimukset

Ennen MCP-kehitykseen ryhtymistä varmista, että sinulla on:

- **Kehitysympäristö**: Valitsemallesi kielelle (C#, Java, Python, TypeScript tai JavaScript)
- **IDE/Editori**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm tai mikä tahansa nykyaikainen koodieditori
- **Pakettien hallintaohjelmat**: NuGet, Maven/Gradle, pip tai npm/yarn
- **API-avaimet**: Kaikille AI-palveluille, joita aiot käyttää isäntäsovelluksissasi


### Viralliset SDK:t

Tulevissa luvuissa näet ratkaisuja, jotka on rakennettu Pythonilla, TypeScriptilä, Javalla ja .NET:llä. Tässä ovat kaikki virallisesti tuetut SDK:t.

MCP tarjoaa viralliset SDK:t useille kielille:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Ylläpidetty yhteistyössä Microsoftin kanssa
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Ylläpidetty yhteistyössä Spring AI:n kanssa
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Virallinen TypeScript-toteutus
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Virallinen Python-toteutus
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Virallinen Kotlin-toteutus
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Ylläpidetty yhteistyössä Loopwork AI:n kanssa
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Virallinen Rust-toteutus

## Keskeiset opit

- MCP-kehitysympäristön perustaminen on suoraviivaista kielikohtaisten SDK:iden avulla
- MCP-palvelinten rakentaminen tarkoittaa työkalujen luomista ja rekisteröintiä selkeillä skeemoilla
- MCP-asiakkaat yhdistävät palvelimiin ja malleihin hyödyntääkseen laajennettuja ominaisuuksia
- Testaus ja virheenkorjaus ovat olennaisia luotettavien MCP-toteutusten varmistamiseksi
- Julkaisuvaihtoehdot vaihtelevat paikallisesta kehityksestä pilvipohjaisiin ratkaisuihin

## Harjoittelu

Meillä on joukko esimerkkejä, jotka täydentävät kaikkien tämän osion lukujen harjoituksia. Lisäksi jokaisessa luvussa on omat harjoituksensa ja tehtävänsä.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Lisäresurssit

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Mitä seuraavaksi

Seuraavaksi: [Ensimmäisen MCP-palvelimen luominen](/03-GettingStarted/01-first-server/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ota huomioon, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.