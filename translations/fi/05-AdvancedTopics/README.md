<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a5c1d9e9856024d23da4a65a847c75ac",
  "translation_date": "2025-07-18T07:18:17+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "fi"
}
-->
# Edistyneet aiheet MCP:ssä

Tässä luvussa käsitellään useita edistyneitä aiheita Model Context Protocolin (MCP) toteutuksessa, kuten monimodaalinen integraatio, skaalautuvuus, tietoturvan parhaat käytännöt ja yritysintegrointi. Nämä aiheet ovat keskeisiä, kun rakennetaan vankkoja ja tuotantovalmiita MCP-sovelluksia, jotka pystyvät vastaamaan nykyaikaisten tekoälyjärjestelmien vaatimuksiin.

## Yleiskatsaus

Tässä oppitunnissa perehdytään edistyneisiin MCP-toteutuksen käsitteisiin, keskittyen monimodaaliseen integraatioon, skaalautuvuuteen, tietoturvan parhaisiin käytäntöihin ja yritysintegrointiin. Nämä aiheet ovat välttämättömiä tuotantotason MCP-sovellusten rakentamisessa, jotka pystyvät käsittelemään monimutkaisia vaatimuksia yritysympäristöissä.

## Oppimistavoitteet

Oppitunnin lopussa osaat:

- Toteuttaa monimodaalisia ominaisuuksia MCP-kehyksissä
- Suunnitella skaalautuvia MCP-arkkitehtuureja vaativiin käyttötapauksiin
- Soveltaa MCP:n tietoturvaperiaatteiden mukaisia parhaita käytäntöjä
- Integroitu MCP yritysten tekoälyjärjestelmiin ja -kehyksiin
- Optimoida suorituskykyä ja luotettavuutta tuotantoympäristöissä

## Oppitunnit ja esimerkkiprojektit

| Linkki | Otsikko | Kuvaus |
|--------|---------|--------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrointi Azureen | Opettele, miten MCP-palvelimesi integroidaan Azureen |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP monimodaaliset esimerkit | Esimerkkejä ääni-, kuva- ja monimodaalisista vastauksista |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalistinen Spring Boot -sovellus, joka näyttää OAuth2:n käytön MCP:n kanssa sekä valtuutus- että resurssipalvelimena. Demonstroi turvallista tokenin myöntämistä, suojattuja päätepisteitä, Azure Container Apps -käyttöönottoa ja API Management -integraatiota. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Juurikontekstit | Lisätietoa juurikontekstista ja sen toteuttamisesta |
| [5.5 Routing](./mcp-routing/README.md) | Reititys | Opettele erilaisia reititystyyppejä |
| [5.6 Sampling](./mcp-sampling/README.md) | Otanta | Opettele työskentelemään otannan kanssa |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaalaus | Opettele skaalauksesta |
| [5.8 Security](./mcp-security/README.md) | Tietoturva | Suojaa MCP-palvelimesi |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Verkkohaku MCP | Python-pohjainen MCP-palvelin ja -asiakas, jotka integroituvat SerpAPI:in reaaliaikaista web-, uutis-, tuotehakua ja kysymys-vastaus -toimintoja varten. Demonstroi monityökalujen orkestrointia, ulkoisten API:en integraatiota ja vankkaa virheenkäsittelyä. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Suoratoisto | Reaaliaikainen datan suoratoisto on nykymaailmassa välttämätöntä, kun yritykset ja sovellukset tarvitsevat välitöntä pääsyä tietoihin tehdäkseen oikea-aikaisia päätöksiä. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Verkkohaku | Reaaliaikainen verkkohaku ja miten MCP muuttaa sitä tarjoamalla standardoidun lähestymistavan kontekstinhallintaan tekoälymallien, hakukoneiden ja sovellusten välillä. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID -todennus | Microsoft Entra ID tarjoaa vahvan pilvipohjaisen identiteetin ja pääsynhallinnan ratkaisun, joka varmistaa, että vain valtuutetut käyttäjät ja sovellukset voivat olla vuorovaikutuksessa MCP-palvelimesi kanssa. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry -integraatio | Opettele, miten Model Context Protocol -palvelimet integroidaan Azure AI Foundry -agenttien kanssa, mahdollistaen tehokkaan työkalujen orkestroinnin ja yritysten tekoälyominaisuudet standardoitujen ulkoisten tietolähteiden yhteyksien avulla. |
| [5.14 Context Engineering](./mcp-contextengineering/README.md) | Kontekstisuunnittelu | Kontekstisuunnittelutekniikoiden tulevaisuuden mahdollisuudet MCP-palvelimille, mukaan lukien kontekstin optimointi, dynaaminen kontekstinhallinta ja tehokkaat prompttien suunnittelustrategiat MCP-kehyksissä. |

## Lisäviitteet

Ajantasaisimman tiedon saamiseksi edistyneistä MCP-aiheista, tutustu:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Keskeiset opit

- Monimodaaliset MCP-toteutukset laajentavat tekoälyn kykyjä tekstinkäsittelyn ulkopuolelle
- Skaalautuvuus on välttämätöntä yrityskäyttöönotossa ja siihen voidaan vastata horisontaalisella ja vertikaalisella skaalaamisella
- Kattavat tietoturvatoimet suojaavat dataa ja varmistavat asianmukaisen pääsynhallinnan
- Yritysintegrointi alustoihin kuten Azure OpenAI ja Microsoft AI Foundry parantaa MCP:n kyvykkyyksiä
- Edistyneet MCP-toteutukset hyötyvät optimoiduista arkkitehtuureista ja huolellisesta resurssien hallinnasta

## Harjoitus

Suunnittele yritystason MCP-toteutus tiettyä käyttötapausta varten:

1. Määrittele monimodaaliset vaatimukset käyttötapauksellesi
2. Laadi tietoturvatoimet arkaluontoisen datan suojaamiseksi
3. Suunnittele skaalautuva arkkitehtuuri, joka kestää vaihtelevan kuormituksen
4. Suunnittele integraatiopisteet yritysten tekoälyjärjestelmiin
5. Dokumentoi mahdolliset suorituskyvyn pullonkaulat ja niiden lieventämisstrategiat

## Lisäresurssit

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Mitä seuraavaksi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.