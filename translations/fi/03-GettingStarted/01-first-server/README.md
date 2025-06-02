<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:37:14+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "fi"
}
-->
### -2- Luo projekti

Nyt kun olet asentanut SDK:n, luodaan seuraavaksi projekti:

### -3- Luo projektitiedostot

### -4- Luo palvelinkoodi

### -5- Lisää työkalu ja resurssi

Lisää työkalu ja resurssi seuraavalla koodilla:

### -6 Lopullinen koodi

Lisätään viimeiset koodit, jotta palvelin voi käynnistyä:

### -7- Testaa palvelin

Käynnistä palvelin seuraavalla komennolla:

### -8- Käynnistä inspectorilla

Inspector on loistava työkalu, joka käynnistää palvelimesi ja antaa sinun olla vuorovaikutuksessa sen kanssa, jotta voit testata sen toimivuuden. Käynnistetään se:

> [!NOTE]
> Komento-kentässä voi näyttää erilaiselta, koska se sisältää käskyn palvelimen ajamiseen juuri sinun valitsemallasi ajoympäristöllä.

Näet seuraavan käyttöliittymän:

![Yhdistä](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.fi.png)

1. Yhdistä palvelimeen valitsemalla Yhdistä-painike  
   Kun olet yhdistänyt palvelimeen, näet nyt seuraavan:

   ![Yhdistetty](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.fi.png)

2. Valitse "Tools" ja "listTools", näet "Add" -vaihtoehdon, valitse "Add" ja täytä parametrien arvot.

   Näet seuraavan vastauksen, eli tuloksen "add"-työkalusta:

   ![Add-työkalun tulos](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.fi.png)

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

## Keskeiset opit

- MCP-kehitysympäristön perustaminen on helppoa kielikohtaisten SDK:iden avulla
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
3. Käynnistä inspector-työkalu varmistaaksesi, että palvelin toimii odotetusti.
4. Testaa toteutusta erilaisilla syötteillä.

## Ratkaisu

[Ratkaisu](./solution/README.md)

## Lisäresurssit

- [MCP GitHub-repositorio](https://github.com/microsoft/mcp-for-beginners)

## Mitä seuraavaksi

Seuraavaksi: [Aloittaminen MCP-asiakkaiden kanssa](/03-GettingStarted/02-client/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.