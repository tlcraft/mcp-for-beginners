<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b1cffc51b82049ac3d5e88db0ff4a0a1",
  "translation_date": "2025-06-13T00:14:45+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "fi"
}
-->
# Edistyneet aiheet MCP:ssä

Tämä luku käsittelee sarjaa edistyneitä aiheita Model Context Protocolin (MCP) toteutuksessa, mukaan lukien monimodaalinen integrointi, skaalautuvuus, tietoturvan parhaat käytännöt ja yritysintegrointi. Nämä aiheet ovat ratkaisevan tärkeitä, kun rakennetaan vankkoja ja tuotantovalmiita MCP-sovelluksia, jotka pystyvät vastaamaan nykyaikaisten tekoälyjärjestelmien vaatimuksiin.

## Yleiskatsaus

Tässä oppitunnissa perehdytään edistyneisiin MCP-toteutuksen käsitteisiin keskittyen monimodaaliseen integrointiin, skaalautuvuuteen, tietoturvan parhaisiin käytäntöihin ja yritysintegrointiin. Nämä aiheet ovat olennaisia tuotantoluokan MCP-sovellusten rakentamisessa, jotka pystyvät käsittelemään monimutkaisia vaatimuksia yritysympäristöissä.

## Oppimistavoitteet

Tämän oppitunnin lopussa osaat:

- Toteuttaa monimodaalisia ominaisuuksia MCP-kehyksissä
- Suunnitella skaalautuvia MCP-arkkitehtuureja vaativiin käyttötapauksiin
- Soveltaa tietoturvan parhaita käytäntöjä MCP:n tietoturvaperiaatteiden mukaisesti
- Integroi MCP yritysten tekoälyjärjestelmiin ja kehyksiin
- Optimoida suorituskykyä ja luotettavuutta tuotantoympäristöissä

## Oppitunnit ja esimerkkiprojektit

| Linkki | Otsikko | Kuvaus |
|--------|---------|--------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrointi Azureen | Opi, miten MCP-palvelimesi integroidaan Azureen |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Monimodaaliset esimerkit | Esimerkkejä ääni-, kuva- ja monimodaalisista vastauksista |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalistinen Spring Boot -sovellus, joka näyttää OAuth2:n käytön MCP:n kanssa sekä valtuutus- että resurssipalvelimena. Demonstroi turvallista tokenin myöntämistä, suojattuja päätepisteitä, Azure Container Apps -käyttöönottoa ja API Management -integraatiota. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root-kontekstit | Lisätietoa root-konteksteista ja niiden toteuttamisesta |
| [5.5 Routing](./mcp-routing/README.md) | Reititys | Opettele erilaiset reititystyypit |
| [5.6 Sampling](./mcp-sampling/README.md) | Otanta | Opettele työskentelemään otannan kanssa |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaalaus | Opettele skaalausta |
| [5.8 Security](./mcp-security/README.md) | Tietoturva | Turvaa MCP-palvelimesi |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web-haku MCP | Python MCP -palvelin ja asiakas, jotka integroivat SerpAPI:n reaaliaikaiseen verkko-, uutis-, tuotehakuun ja kysymys-vastaus-toimintoihin. Demonstroi monityökalujen orkestrointia, ulkoisten API:en integraatiota ja vankkaa virheenkäsittelyä. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Reaaliaikainen datavirta on nykymaailmassa välttämätöntä, kun yritykset ja sovellukset tarvitsevat välitöntä pääsyä tietoihin tehdäkseen oikea-aikaisia päätöksiä. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Verkkohaku | Reaaliaikainen verkkohaku ja miten MCP muuttaa reaaliaikaista verkkohakua tarjoamalla standardoidun lähestymistavan kontekstinhallintaan tekoälymallien, hakukoneiden ja sovellusten välillä. |

## Lisäviitteet

Ajantasaisimman tiedon saamiseksi edistyneistä MCP-aiheista tutustu seuraaviin:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Keskeiset opit

- Monimodaaliset MCP-toteutukset laajentavat tekoälyn kykyjä tekstinkäsittelyn ulkopuolelle
- Skaalautuvuus on välttämätöntä yritysratkaisuissa, ja siihen voidaan vastata vaakasuoran ja pystysuoran skaalaamisen avulla
- Kattavat tietoturvatoimet suojaavat dataa ja varmistavat asianmukaisen pääsynhallinnan
- Yritysintegrointi alustoihin kuten Azure OpenAI ja Microsoft AI Foundry vahvistaa MCP:n kyvykkyyksiä
- Edistyneet MCP-toteutukset hyötyvät optimoiduista arkkitehtuureista ja huolellisesta resurssien hallinnasta

## Harjoitus

Suunnittele yritystason MCP-toteutus tiettyä käyttötapausta varten:

1. Määrittele käyttötapauksesi monimodaaliset vaatimukset
2. Laadi tietoturvakontrollit arkaluonteisen datan suojaamiseksi
3. Suunnittele skaalautuva arkkitehtuuri, joka pystyy käsittelemään vaihtelevaa kuormitusta
4. Suunnittele integraatiopisteet yritysten tekoälyjärjestelmien kanssa
5. Dokumentoi mahdolliset suorituskyvyn pullonkaulat ja lieventämisstrategiat

## Lisäresurssit

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Mitä seuraavaksi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ota huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulisi pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai virhetulkintojen seurauksista.