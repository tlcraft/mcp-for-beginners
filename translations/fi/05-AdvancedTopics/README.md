<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:36:33+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "fi"
}
-->
# Edistyneet aiheet MCP:ssä

Tässä luvussa käsitellään useita edistyneitä aiheita Model Context Protocolin (MCP) toteutuksessa, kuten monimodaalinen integraatio, skaalautuvuus, turvallisuuden parhaat käytännöt ja yritysintegrointi. Nämä aiheet ovat keskeisiä vahvojen ja tuotantovalmiiden MCP-sovellusten rakentamisessa, jotka pystyvät vastaamaan nykyaikaisten tekoälyjärjestelmien vaatimuksiin.

## Yleiskatsaus

Tässä oppitunnissa syvennytään Model Context Protocolin toteutuksen edistyneisiin käsitteisiin, painottaen monimodaalista integraatiota, skaalautuvuutta, turvallisuuden parhaita käytäntöjä ja yritysintegrointia. Nämä aiheet ovat välttämättömiä tuotantotason MCP-sovellusten rakentamisessa, jotka pystyvät käsittelemään monimutkaisia vaatimuksia yritysympäristöissä.

## Oppimistavoitteet

Tämän oppitunnin jälkeen osaat:

- Toteuttaa monimodaaliset ominaisuudet MCP-kehyksissä
- Suunnitella skaalautuvia MCP-arkkitehtuureja vaativiin käyttötapauksiin
- Soveltaa turvallisuuden parhaita käytäntöjä MCP:n turvallisuusperiaatteiden mukaisesti
- Integroi MCP yritysten tekoälyjärjestelmiin ja kehyksiin
- Optimoida suorituskykyä ja luotettavuutta tuotantoympäristöissä

## Oppitunnit ja esimerkkiprojektit

| Linkki | Otsikko | Kuvaus |
|--------|---------|--------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrointi Azureen | Opi, miten MCP-palvelimesi integroidaan Azureen |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP monimodaaliset esimerkit | Esimerkkejä ääni-, kuva- ja monimodaalisista vastauksista |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimipainoinen Spring Boot -sovellus, joka näyttää OAuth2:n käytön MCP:n kanssa sekä valtuutus- että resurssipalvelimena. Esittelee turvallisen tokenin myöntämisen, suojatut päätepisteet, Azure Container Apps -käyttöönoton ja API Management -integraation. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Juurikontekstit | Lisätietoa juurikonteksteista ja niiden toteutuksesta |
| [5.5 Routing](./mcp-routing/README.md) | Reititys | Opettele erilaisia reititystyyppejä |
| [5.6 Sampling](./mcp-sampling/README.md) | Otanta | Opi työskentelemään otannan kanssa |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaalaus | Opettele skaalauksesta |
| [5.8 Security](./mcp-security/README.md) | Turvallisuus | Varmista MCP-palvelimesi turvallisuus |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web-haku MCP | Python MCP -palvelin ja asiakas, jotka integroituvat SerpAPI:n kanssa reaaliaikaiseen web-, uutis-, tuotehakuun ja kysymys-vastaus -toimintoihin. Esittelee monityökalujen orkestroinnin, ulkoisten API:en integroinnin ja vahvan virheenkäsittelyn. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Suoratoisto | Reaaliaikainen datavirtaus on nykypäivän tietoon perustuvassa maailmassa välttämätöntä, kun yritykset ja sovellukset tarvitsevat välitöntä pääsyä tietoon tehdäkseen oikea-aikaisia päätöksiä. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web-haku | Kuinka MCP muuttaa reaaliaikaista web-hakua tarjoamalla standardoidun lähestymistavan kontekstinhallintaan tekoälymallien, hakukoneiden ja sovellusten välillä. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID -todennus | Microsoft Entra ID tarjoaa vankan pilvipohjaisen identiteetin ja pääsynhallinnan ratkaisun, joka varmistaa, että vain valtuutetut käyttäjät ja sovellukset voivat olla vuorovaikutuksessa MCP-palvelimesi kanssa. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry -integraatio | Opi, miten Model Context Protocol -palvelimet integroidaan Azure AI Foundry -agenttien kanssa, mahdollistaen tehokkaan työkalujen orkestroinnin ja yritystason tekoälyominaisuudet standardoitujen ulkoisten tietolähteiden yhteyksien avulla. |

## Lisäviitteet

Ajantasaisimman tiedon saamiseksi edistyneistä MCP-aiheista tutustu:
- [MCP-dokumentaatio](https://modelcontextprotocol.io/)
- [MCP-spesifikaatio](https://spec.modelcontextprotocol.io/)
- [GitHub-repositorio](https://github.com/modelcontextprotocol)

## Tärkeimmät opit

- Monimodaaliset MCP-toteutukset laajentavat tekoälyn kyvykkyyksiä tekstinkäsittelyn ulkopuolelle
- Skaalautuvuus on välttämätöntä yrityskäyttöönotossa ja siihen voidaan vastata vaakasuoran ja pystysuoran skaalaamisen avulla
- Kattavat turvallisuustoimenpiteet suojaavat dataa ja varmistavat asianmukaisen pääsynhallinnan
- Yritysintegrointi alustojen kuten Azure OpenAI:n ja Microsoft AI Foundryn kanssa vahvistaa MCP:n kyvykkyyksiä
- Edistyneet MCP-toteutukset hyötyvät optimoiduista arkkitehtuureista ja huolellisesta resurssien hallinnasta

## Harjoitus

Suunnittele yritystason MCP-toteutus tiettyä käyttötapausta varten:

1. Määrittele käyttötapauksesi monimodaaliset vaatimukset
2. Laadi turvatoimet herkän datan suojaamiseksi
3. Suunnittele skaalautuva arkkitehtuuri, joka pystyy käsittelemään vaihtelevaa kuormitusta
4. Suunnittele integraatiopisteet yritysten tekoälyjärjestelmiin
5. Dokumentoi mahdolliset suorituskyvyn pullonkaulat ja niiden lieventämiskeinot

## Lisäresurssit

- [Azure OpenAI -dokumentaatio](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry -dokumentaatio](https://learn.microsoft.com/en-us/ai-services/)

---

## Seuraavaksi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ole hyvä ja huomioi, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.