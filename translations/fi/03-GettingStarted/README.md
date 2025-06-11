<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:12:07+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "fi"
}
-->
## Aloittaminen  

Tämä osio koostuu useista oppitunneista:

- **1 Ensimmäinen palvelimesi**, tässä ensimmäisessä oppitunnissa opit luomaan ensimmäisen palvelimesi ja tarkastelemaan sitä inspector-työkalulla, joka on arvokas tapa testata ja virheenkorjata palvelinta, [oppitunnille](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, tässä oppitunnissa opit kirjoittamaan clientin, joka voi muodostaa yhteyden palvelimeesi, [oppitunnille](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM**, vielä parempi tapa kirjoittaa client on lisätä siihen LLM, jotta se voi "neuvotella" palvelimesi kanssa siitä, mitä tehdä, [oppitunnille](/03-GettingStarted/03-llm-client/README.md)

- **4 Palvelimen käyttäminen GitHub Copilot Agent -tilassa Visual Studio Codessa**. Tässä tarkastelemme MCP Serverin ajamista suoraan Visual Studio Codesta, [oppitunnille](/03-GettingStarted/04-vscode/README.md)

- **5 Käyttö SSE:n (Server Sent Events) kautta** SSE on standardi palvelimelta clientille tapahtuvaan suoratoistoon, jonka avulla palvelimet voivat työntää reaaliaikaisia päivityksiä clientille HTTP:n yli [oppitunnille](/03-GettingStarted/05-sse-server/README.md)

- **6 AI Toolkitin hyödyntäminen VSCode:ssa** MCP Clientien ja Serverien kulutukseen ja testaamiseen [oppitunnille](/03-GettingStarted/06-aitk/README.md)

- **7 Testaus**. Tässä keskitymme erityisesti siihen, miten voimme testata palvelintamme ja clienttiamme eri tavoin, [oppitunnille](/03-GettingStarted/07-testing/README.md)

- **8 Julkaisu**. Tässä luvussa tarkastelemme erilaisia tapoja julkaista MCP-ratkaisuja, [oppitunnille](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) on avoin protokolla, joka standardisoi, miten sovellukset tarjoavat kontekstia LLM:ille. Ajattele MCP:tä kuin USB-C-porttina tekoälysovelluksille – se tarjoaa standardoidun tavan yhdistää tekoälymalleja erilaisiin tietolähteisiin ja työkaluihin.

## Oppimistavoitteet

Tämän oppitunnin jälkeen osaat:

- Määrittää MCP-kehitysympäristöt C#:lle, Javalle, Pythonille, TypeScriptille ja JavaScriptille
- Rakentaa ja julkaista perus MCP-palvelimia räätälöidyillä ominaisuuksilla (resurssit, kehotteet ja työkalut)
- Luoda isäntäsovelluksia, jotka yhdistävät MCP-palvelimiin
- Testata ja virheenkorjata MCP-toteutuksia
- Ymmärtää yleisiä asennushaasteita ja niiden ratkaisuja
- Yhdistää MCP-toteutuksesi suosittuihin LLM-palveluihin

## MCP-ympäristön määrittäminen

Ennen kuin aloitat työskentelyn MCP:n kanssa, on tärkeää valmistella kehitysympäristösi ja ymmärtää perus työnkulku. Tämä osio opastaa sinut alkuasetuksissa, jotta MCP:n käyttö lähtisi sujuvasti käyntiin.

### Esivaatimukset

Ennen MCP-kehitykseen sukeltamista varmista, että sinulla on:

- **Kehitysympäristö**: Valitsemallesi kielelle (C#, Java, Python, TypeScript tai JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm tai jokin nykyaikainen koodieditori
- **Paketinhallintaohjelmat**: NuGet, Maven/Gradle, pip tai npm/yarn
- **API-avaimet**: Kaikille tekoälypalveluille, joita aiot käyttää isäntäsovelluksissasi


### Viralliset SDK:t

Tulevissa luvuissa näet ratkaisuja, jotka on rakennettu Pythonilla, TypeScriptille, Javalle ja .NET:lle. Tässä ovat kaikki virallisesti tuetut SDK:t.

MCP tarjoaa virallisia SDK:ita useille kielille:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Ylläpidetään yhteistyössä Microsoftin kanssa
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Ylläpidetään yhteistyössä Spring AI:n kanssa
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Virallinen TypeScript-toteutus
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Virallinen Python-toteutus
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Virallinen Kotlin-toteutus
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Ylläpidetään yhteistyössä Loopwork AI:n kanssa
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Virallinen Rust-toteutus

## Keskeiset opit

- MCP-kehitysympäristön pystyttäminen on suoraviivaista kielikohtaisten SDK:iden avulla
- MCP-palvelinten rakentaminen sisältää työkalujen luomisen ja rekisteröinnin selkeillä skeemoilla
- MCP-clientit yhdistävät palvelimiin ja malleihin hyödyntääkseen laajennettuja ominaisuuksia
- Testaus ja virheenkorjaus ovat välttämättömiä luotettaville MCP-toteutuksille
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
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeiden tietojen osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai tulkinnoista.