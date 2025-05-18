<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:11:42+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "fi"
}
-->
## Aloittaminen  

Tämä osio koostuu useista oppitunneista:

- **-1- Ensimmäinen palvelimesi**, tässä ensimmäisessä oppitunnissa opit luomaan ensimmäisen palvelimesi ja tarkastelemaan sitä tarkastustyökalulla, mikä on arvokas tapa testata ja debugata palvelintasi, [oppitunnille](/03-GettingStarted/01-first-server/README.md)

- **-2- Asiakas**, tässä oppitunnissa opit kirjoittamaan asiakkaan, joka voi yhdistää palvelimeesi, [oppitunnille](/03-GettingStarted/02-client/README.md)

- **-3- Asiakas LLM:n kanssa**, vielä parempi tapa kirjoittaa asiakas on lisätä siihen LLM, jotta se voi "neuvotella" palvelimesi kanssa siitä, mitä tehdä, [oppitunnille](/03-GettingStarted/03-llm-client/README.md)

- **-4- Palvelimen käyttö GitHub Copilot Agent -tilassa Visual Studio Codessa**. Tässä tarkastellaan MCP-palvelimen suorittamista Visual Studio Codessa, [oppitunnille](/03-GettingStarted/04-vscode/README.md)

- **-5- Kulutus SSE:stä (Server Sent Events)** SSE on standardi palvelimen ja asiakkaan väliseen suoratoistoon, mikä mahdollistaa palvelimien reaaliaikaisten päivitysten lähettämisen asiakkaille HTTP:n kautta [oppitunnille](/03-GettingStarted/05-sse-server/README.md)

- **-6- AI Toolkitin hyödyntäminen VSCodea varten** MCP-asiakkaidesi ja -palvelimiesi kulutukseen ja testaamiseen [oppitunnille](/03-GettingStarted/06-aitk/README.md)

- **-7 Testaus**. Tässä keskitymme erityisesti siihen, miten voimme testata palvelintamme ja asiakastamme eri tavoin, [oppitunnille](/03-GettingStarted/07-testing/README.md)

- **-8- Käyttöönotto**. Tässä luvussa tarkastellaan erilaisia tapoja ottaa MCP-ratkaisusi käyttöön, [oppitunnille](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) on avoin protokolla, joka standardoi, kuinka sovellukset tarjoavat kontekstia LLM:ille. Ajattele MCP:tä kuin USB-C-porttia tekoälysovelluksille - se tarjoaa standardoidun tavan yhdistää tekoälymallit eri tietolähteisiin ja työkaluihin.

## Oppimistavoitteet

Tämän oppitunnin lopussa osaat:

- Määrittää MCP-kehitysympäristöt C#:lle, Java:lle, Pythonille, TypeScriptille ja JavaScriptille
- Rakentaa ja ottaa käyttöön perus MCP-palvelimia mukautetuilla ominaisuuksilla (resurssit, kehotteet ja työkalut)
- Luoda isäntäsovelluksia, jotka yhdistävät MCP-palvelimiin
- Testata ja debugata MCP-toteutuksia
- Ymmärtää yleisiä asennushaasteita ja niiden ratkaisuja
- Yhdistää MCP-toteutuksesi suosittuihin LLM-palveluihin

## MCP-ympäristön asettaminen

Ennen kuin aloitat työskentelyn MCP:n kanssa, on tärkeää valmistella kehitysympäristösi ja ymmärtää perus työprosessi. Tämä osio opastaa sinut alkuasennusvaiheiden läpi varmistaen sujuvan aloituksen MCP:n kanssa.

### Esivaatimukset

Ennen kuin sukellat MCP-kehitykseen, varmista että sinulla on:

- **Kehitysympäristö**: Valitsemallesi kielelle (C#, Java, Python, TypeScript tai JavaScript)
- **IDE/Editori**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm tai mikä tahansa moderni koodieditori
- **Paketinhallintaohjelmat**: NuGet, Maven/Gradle, pip tai npm/yarn
- **API-avaimet**: Kaikille AI-palveluille, joita aiot käyttää isäntäsovelluksissasi

### Viralliset SDK:t

Tulevissa luvuissa näet ratkaisuja, jotka on rakennettu Pythonilla, TypeScriptillä, Javalla ja .NET:llä. Tässä ovat kaikki virallisesti tuetut SDK:t.

MCP tarjoaa viralliset SDK:t useille kielille:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Ylläpidetty yhteistyössä Microsoftin kanssa
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Ylläpidetty yhteistyössä Spring AI:n kanssa
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Virallinen TypeScript-toteutus
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Virallinen Python-toteutus
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Virallinen Kotlin-toteutus
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Ylläpidetty yhteistyössä Loopwork AI:n kanssa
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Virallinen Rust-toteutus

## Keskeiset huomiot

- MCP-kehitysympäristön asettaminen on suoraviivaista kielenkohtaisilla SDK:illa
- MCP-palvelimien rakentaminen sisältää työkalujen luomisen ja rekisteröinnin selkeillä kaavioilla
- MCP-asiakkaat yhdistävät palvelimiin ja malleihin hyödyntääkseen laajennettuja ominaisuuksia
- Testaus ja debuggaus ovat olennaisia luotettaville MCP-toteutuksille
- Käyttöönottovaihtoehdot vaihtelevat paikallisesta kehityksestä pilvipohjaisiin ratkaisuihin

## Harjoittelu

Meillä on joukko esimerkkejä, jotka täydentävät kaikkien tämän osion lukujen harjoituksia. Lisäksi jokaisella luvulla on omat harjoituksensa ja tehtävänsä

- [Java-laskin](./samples/java/calculator/README.md)
- [.Net-laskin](../../../03-GettingStarted/samples/csharp)
- [JavaScript-laskin](./samples/javascript/README.md)
- [TypeScript-laskin](./samples/typescript/README.md)
- [Python-laskin](../../../03-GettingStarted/samples/python)

## Lisäresurssit

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Mitä seuraavaksi

Seuraavaksi: [Ensimmäisen MCP-palvelimen luominen](/03-GettingStarted/01-first-server/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulee pitää auktoritatiivisena lähteenä. Kriittistä tietoa varten suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinkäsityksistä tai virheellisistä tulkinnoista.