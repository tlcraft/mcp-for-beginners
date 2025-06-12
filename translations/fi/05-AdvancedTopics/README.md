<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T15:54:25+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "fi"
}
-->
# Edistyneet aiheet MCP:ssä

Tämä luku käsittelee sarjaa edistyneitä aiheita Model Context Protocolin (MCP) toteutuksessa, mukaan lukien monimodaalinen integraatio, skaalautuvuus, tietoturvan parhaat käytännöt ja yritysintegraatio. Nämä aiheet ovat keskeisiä, kun rakennetaan vankkoja ja tuotantovalmiita MCP-sovelluksia, jotka pystyvät vastaamaan nykyaikaisten tekoälyjärjestelmien vaatimuksiin.

## Yleiskatsaus

Tässä oppitunnissa perehdytään edistyneisiin käsitteisiin Model Context Protocolin toteutuksessa, keskittyen monimodaaliseen integraatioon, skaalautuvuuteen, tietoturvan parhaisiin käytäntöihin ja yritysintegraatioon. Nämä aiheet ovat välttämättömiä tuotantotason MCP-sovellusten rakentamisessa, jotka pystyvät käsittelemään monimutkaisia vaatimuksia yritysympäristöissä.

## Oppimistavoitteet

Tämän oppitunnin jälkeen osaat:

- Toteuttaa monimodaaliset ominaisuudet MCP-kehyksissä
- Suunnitella skaalautuvia MCP-arkkitehtuureja vaativiin käyttötapauksiin
- Soveltaa MCP:n tietoturvaperiaatteiden mukaisia tietoturvan parhaita käytäntöjä
- Integroida MCP yritysten tekoälyjärjestelmiin ja kehyksiin
- Optimoida suorituskykyä ja luotettavuutta tuotantoympäristöissä

## Oppitunnit ja esimerkkiprojektit

| Linkki | Otsikko | Kuvaus |
|--------|---------|--------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrointi Azureen | Opi, miten MCP-palvelimesi integroidaan Azureen |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP monimodaaliset esimerkit | Esimerkkejä ääni-, kuva- ja monimodaalisista vastauksista |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimipohjainen Spring Boot -sovellus, joka näyttää OAuth2:n käytön MCP:n kanssa sekä valtuutus- että resurssipalvelimena. Demonstroi turvallista tokenin myöntämistä, suojattuja päätepisteitä, Azure Container Apps -käyttöönottoa ja API Management -integraatiota. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Juuri-kontekstit | Lisätietoa juuri-konteksteista ja niiden toteuttamisesta |
| [5.5 Routing](./mcp-routing/README.md) | Reititys | Opettele eri reititystyypit |
| [5.6 Sampling](./mcp-sampling/README.md) | Otanta | Opettele työskentelemään otannan kanssa |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaalaus | Opettele skaalausta |
| [5.8 Security](./mcp-security/README.md) | Tietoturva | Suojaa MCP-palvelimesi |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web-haku MCP | Python-pohjainen MCP-palvelin ja asiakas, jotka integroituvat SerpAPI:hin reaaliaikaiseen web-, uutis-, tuotetietohakuun ja kysymys-vastaus-toimintoihin. Demonstroi monityökalujen orkestrointia, ulkoisten API:en integraatiota ja vankkaa virheenkäsittelyä. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Suoratoisto | Reaaliaikainen datan suoratoisto on nykypäivän dataohjautuvassa maailmassa välttämätöntä, sillä yritykset ja sovellukset tarvitsevat välitöntä pääsyä tietoihin tehdäkseen oikea-aikaisia päätöksiä. |

## Lisäviitteet

Ajantasaisimman tiedon saamiseksi edistyneistä MCP-aiheista tutustu seuraaviin:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Keskeiset opit

- Monimodaaliset MCP-toteutukset laajentavat tekoälyn kykyjä tekstinkäsittelyn ulkopuolelle
- Skaalautuvuus on välttämätöntä yrityskäyttöönotossa, ja siihen voidaan vastata horisontaalisella ja vertikaalisella skaalaamisella
- Kattavat tietoturvatoimet suojaavat dataa ja varmistavat asianmukaisen pääsynhallinnan
- Yritysintegraatio alustoihin kuten Azure OpenAI ja Microsoft AI Foundry parantaa MCP:n mahdollisuuksia
- Edistyneet MCP-toteutukset hyötyvät optimoiduista arkkitehtuureista ja huolellisesta resurssien hallinnasta

## Harjoitus

Suunnittele yritystason MCP-toteutus tietylle käyttötapaukselle:

1. Määrittele monimodaaliset vaatimukset käyttötapauksellesi
2. Laadi tietoturvatoimenpiteet arkaluonteisen datan suojaamiseksi
3. Suunnittele skaalautuva arkkitehtuuri, joka kestää vaihtelevia kuormia
4. Suunnittele integraatiopisteet yritysten tekoälyjärjestelmien kanssa
5. Dokumentoi mahdolliset suorituskyvyn pullonkaulat ja niiden lieventämiskeinot

## Lisäresurssit

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Mitä seuraavaksi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä on katsottava auktoriteettiseksi lähteeksi. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.