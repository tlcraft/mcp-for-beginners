<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:37:46+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "fi"
}
-->
### -2- Luo projekti

Nyt kun SDK on asennettu, luodaan seuraavaksi projekti:

### -3- Luo projektitiedostot

### -4- Kirjoita palvelinkoodi

### -5- Lisää työkalu ja resurssi

Lisää työkalu ja resurssi lisäämällä seuraava koodi:

### -6- Lopullinen koodi

Lisätään viimeinen koodi, jotta palvelin voi käynnistyä:

### -7- Testaa palvelin

Käynnistä palvelin seuraavalla komennolla:

### -8- Käynnistä inspectorilla

Inspector on loistava työkalu, joka käynnistää palvelimesi ja antaa sinun olla vuorovaikutuksessa sen kanssa, jotta voit testata sen toimivuuden. Käynnistetään se:

> [!NOTE]
> komentokentässä voi näyttää erilaiselta, koska siinä on käsky palvelimen ajamiseen valitsemallasi ajoympäristöllä

Näet seuraavan käyttöliittymän:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.fi.png)

1. Yhdistä palvelimeen valitsemalla Connect-painike  
   Kun olet yhdistänyt palvelimeen, näet nyt seuraavan:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.fi.png)

2. Valitse "Tools" ja "listTools", näet "Add"-vaihtoehdon, valitse "Add" ja täytä parametrien arvot.

   Näet seuraavan vastauksen, eli "add"-työkalun tuloksen:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.fi.png)

Onnittelut, olet onnistuneesti luonut ja käynnistänyt ensimmäisen palvelimesi!

### Viralliset SDK:t

MCP tarjoaa viralliset SDK:t useille kielille:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – Ylläpidetään yhteistyössä Microsoftin kanssa
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – Ylläpidetään yhteistyössä Spring AI:n kanssa
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – Virallinen TypeScript-toteutus
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – Virallinen Python-toteutus
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – Virallinen Kotlin-toteutus
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – Ylläpidetään yhteistyössä Loopwork AI:n kanssa
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – Virallinen Rust-toteutus

## Tärkeimmät opit

- MCP-kehitysympäristön pystyttäminen on helppoa kielikohtaisten SDK:iden avulla
- MCP-palvelinten rakentaminen sisältää työkalujen luomisen ja rekisteröinnin selkeillä skeemoilla
- Testaus ja virheenkorjaus ovat olennaisia luotettavien MCP-toteutusten varmistamiseksi

## Esimerkit

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Tehtävä

Luo yksinkertainen MCP-palvelin valitsemallasi työkalulla:
1. Toteuta työkalu haluamallasi kielellä (.NET, Java, Python tai JavaScript).
2. Määrittele syöteparametrit ja palautusarvot.
3. Käynnistä inspector-työkalu varmistaaksesi, että palvelin toimii oikein.
4. Testaa toteutusta erilaisilla syötteillä.

## Ratkaisu

[Ratkaisu](./solution/README.md)

## Lisäresurssit

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Mitä seuraavaksi

Seuraavaksi: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai tulkinnoista.