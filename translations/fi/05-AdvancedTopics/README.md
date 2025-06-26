<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T14:07:39+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "fi"
}
-->
# Edistyneet aiheet MCP:ssä

Tässä luvussa käsitellään sarjaa edistyneitä aiheita Model Context Protocolin (MCP) toteutuksessa, mukaan lukien monimuotoisen integraation, skaalautuvuuden, turvallisuuden parhaat käytännöt ja yritysintegroinnin. Nämä aiheet ovat olennaisia vankkojen ja tuotantovalmiiden MCP-sovellusten rakentamisessa, jotka pystyvät vastaamaan nykyaikaisten tekoälyjärjestelmien vaatimuksiin.

## Yleiskatsaus

Tässä oppitunnissa perehdytään edistyneisiin käsitteisiin Model Context Protocolin toteutuksessa, keskittyen monimuotoiseen integraatioon, skaalautuvuuteen, turvallisuuden parhaisiin käytäntöihin ja yritysintegrointiin. Nämä aiheet ovat välttämättömiä tuotantotason MCP-sovellusten rakentamisessa, jotka pystyvät käsittelemään monimutkaisia vaatimuksia yritysympäristöissä.

## Oppimistavoitteet

Tämän oppitunnin jälkeen osaat:

- Toteuttaa monimuotoisia ominaisuuksia MCP-kehyksissä
- Suunnitella skaalautuvia MCP-arkkitehtuureja vaativiin käyttötapauksiin
- Soveltaa MCP:n turvallisuusperiaatteiden mukaisia parhaimpia käytäntöjä
- Integroida MCP:n yritysten tekoälyjärjestelmiin ja -kehyksiin
- Optimoida suorituskykyä ja luotettavuutta tuotantoympäristöissä

## Oppitunnit ja esimerkkiprojektit

| Linkki | Otsikko | Kuvaus |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrointi Azureen | Opi integroimaan MCP-palvelimesi Azureen |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP monimuotoiset esimerkit | Esimerkkejä ääni-, kuva- ja monimuotoisista vastauksista |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalistinen Spring Boot -sovellus, joka näyttää OAuth2:n käytön MCP:n kanssa sekä valtuutus- että resurssipalvelimena. Esittelee turvallisen tokenin myöntämisen, suojatut päätepisteet, Azure Container Apps -käyttöönoton ja API Management -integraation. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Juurikontekstit | Opi lisää juurikonteksteista ja niiden toteutuksesta |
| [5.5 Routing](./mcp-routing/README.md) | Reititys | Tutustu erilaisiin reititystyyppeihin |
| [5.6 Sampling](./mcp-sampling/README.md) | Otanta | Opi työskentelemään otannan kanssa |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaalaus | Tutustu skaalaamiseen |
| [5.8 Security](./mcp-security/README.md) | Turvallisuus | Varmista MCP-palvelimesi turvallisuus |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web-haku MCP | Python MCP -palvelin ja asiakas, jotka integroivat SerpAPI:n reaaliaikaiseen web-, uutis-, tuotehakuun ja kysymys-vastaus -toimintoihin. Esittelee monityökalujen orkestroinnin, ulkoisen API-integraation ja vankan virheenkäsittelyn. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Suoratoisto | Reaaliaikainen datan suoratoisto on nykymaailmassa välttämätöntä, kun yritykset ja sovellukset tarvitsevat välitöntä pääsyä tietoon tehdäkseen oikea-aikaisia päätöksiä. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web-haku | Reaaliaikainen web-haku: miten MCP muuttaa reaaliaikaista web-hakua tarjoamalla standardoidun lähestymistavan kontekstinhallintaan tekoälymallien, hakukoneiden ja sovellusten välillä. |
| [5.12 Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID -todennus | Microsoft Entra ID tarjoaa vankan pilvipohjaisen identiteetin ja pääsynhallinnan ratkaisun, joka auttaa varmistamaan, että vain valtuutetut käyttäjät ja sovellukset voivat olla vuorovaikutuksessa MCP-palvelimesi kanssa. |

## Lisäviitteet

Ajantasaisimman tiedon saamiseksi edistyneistä MCP-aiheista, tutustu:
- [MCP-dokumentaatio](https://modelcontextprotocol.io/)
- [MCP-spesifikaatio](https://spec.modelcontextprotocol.io/)
- [GitHub-repositorio](https://github.com/modelcontextprotocol)

## Keskeiset opit

- Monimuotoiset MCP-toteutukset laajentavat tekoälyn kyvykkyyksiä tekstinkäsittelyn ulkopuolelle
- Skaalautuvuus on välttämätöntä yrityskäyttöönotossa, ja sitä voidaan toteuttaa horisontaalisella ja vertikaalisella skaalaamisella
- Kattavat turvallisuustoimet suojaavat dataa ja varmistavat asianmukaisen pääsynhallinnan
- Yritysintegrointi alustoihin kuten Azure OpenAI ja Microsoft AI Foundry parantaa MCP:n kyvykkyyksiä
- Edistyneet MCP-toteutukset hyötyvät optimoiduista arkkitehtuureista ja huolellisesta resurssien hallinnasta

## Harjoitus

Suunnittele yritystason MCP-toteutus tietylle käyttötapaukselle:

1. Määrittele käyttötapauksesi monimuotoiset vaatimukset
2. Laadi tarvittavat turvallisuusvalvontatoimet arkaluonteisen datan suojaamiseksi
3. Suunnittele skaalautuva arkkitehtuuri, joka kestää vaihtelevan kuormituksen
4. Suunnittele integraatiopisteet yritysten tekoälyjärjestelmiin
5. Dokumentoi mahdolliset suorituskykyyn liittyvät pullonkaulat ja niiden lieventämisstrategiat

## Lisäresurssit

- [Azure OpenAI -dokumentaatio](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry -dokumentaatio](https://learn.microsoft.com/en-us/ai-services/)

---

## Mitä seuraavaksi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ota huomioon, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.