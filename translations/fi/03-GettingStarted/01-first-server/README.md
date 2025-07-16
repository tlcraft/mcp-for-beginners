<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:46:37+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "fi"
}
-->
### -2- Luo projekti

Nyt kun SDK on asennettu, luodaan seuraavaksi projekti:

### -3- Luo projektitiedostot

### -4- Luo palvelinkoodi

### -5- Lisää työkalu ja resurssi

Lisää työkalu ja resurssi lisäämällä seuraava koodi:

### -6 Lopullinen koodi

Lisätään viimeinen koodi, jotta palvelin voi käynnistyä:

### -7- Testaa palvelin

Käynnistä palvelin seuraavalla komennolla:

### -8- Käynnistä inspectorilla

Inspector on loistava työkalu, joka käynnistää palvelimesi ja antaa sinun olla vuorovaikutuksessa sen kanssa, jotta voit testata, että se toimii. Käynnistetään se:
> [!NOTE]
> se saattaa näyttää erilaiselta "command"-kentässä, koska se sisältää komennon palvelimen käynnistämiseen käyttämällä omaa ajonaikaasi/
Sinun pitäisi nähdä seuraava käyttöliittymä:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. Yhdistä palvelimeen valitsemalla Connect-painike
  Kun olet yhdistänyt palvelimeen, sinun pitäisi nyt nähdä seuraava:

  ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. Valitse "Tools" ja "listTools", sinun pitäisi nähdä "Add" ilmestyvän, valitse "Add" ja täytä parametrien arvot.

  Sinun pitäisi nähdä seuraava vastaus, eli tulos "add"-työkalusta:

  ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

Onnittelut, olet onnistuneesti luonut ja ajanut ensimmäisen palvelimesi!

### Viralliset SDK:t

MCP tarjoaa virallisia SDK:ita useille kielille:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Ylläpidetään yhteistyössä Microsoftin kanssa
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Ylläpidetään yhteistyössä Spring AI:n kanssa
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Virallinen TypeScript-toteutus
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Virallinen Python-toteutus
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Virallinen Kotlin-toteutus
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Ylläpidetään yhteistyössä Loopwork AI:n kanssa
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Virallinen Rust-toteutus

## Tärkeimmät opit

- MCP-kehitysympäristön pystyttäminen on helppoa kielikohtaisten SDK:iden avulla
- MCP-palvelinten rakentaminen sisältää työkalujen luomisen ja rekisteröinnin selkeillä skeemoilla
- Testaus ja virheenkorjaus ovat olennaisia luotettavien MCP-toteutusten varmistamiseksi

## Esimerkit

- [Java-laskin](../samples/java/calculator/README.md)
- [.Net-laskin](../../../../03-GettingStarted/samples/csharp)
- [JavaScript-laskin](../samples/javascript/README.md)
- [TypeScript-laskin](../samples/typescript/README.md)
- [Python-laskin](../../../../03-GettingStarted/samples/python)

## Tehtävä

Luo yksinkertainen MCP-palvelin valitsemallasi työkalulla:

1. Toteuta työkalu haluamallasi kielellä (.NET, Java, Python tai JavaScript).
2. Määrittele syöteparametrit ja palautusarvot.
3. Aja inspector-työkalu varmistaaksesi, että palvelin toimii odotetusti.
4. Testaa toteutusta erilaisilla syötteillä.

## Ratkaisu

[Ratkaisu](./solution/README.md)

## Lisäresurssit

- [Rakenna agenteja Model Context Protocolilla Azurella](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Etä-MCP Azure Container Appsilla (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Mitä seuraavaksi

Seuraavaksi: [Aloita MCP-asiakkaiden kanssa](../02-client/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.