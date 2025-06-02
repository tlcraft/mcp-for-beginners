<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T19:12:52+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "fi"
}
-->
# Edistyneet aiheet MCP:ssä

Tämä luku käsittelee sarjaa edistyneitä aiheita Model Context Protocolin (MCP) toteutuksessa, mukaan lukien monimodaalinen integraatio, skaalautuvuus, tietoturvan parhaat käytännöt ja yritysintegraatio. Nämä aiheet ovat olennaisia vahvojen ja tuotantovalmiiden MCP-sovellusten rakentamisessa, jotka pystyvät vastaamaan nykyaikaisten tekoälyjärjestelmien vaatimuksiin.

## Yleiskatsaus

Tässä oppitunnissa käsitellään edistyneitä käsitteitä Model Context Protocolin toteutuksessa, keskittyen monimodaaliseen integraatioon, skaalautuvuuteen, tietoturvan parhaisiin käytäntöihin ja yritysintegraatioon. Nämä aiheet ovat välttämättömiä tuotantotason MCP-sovellusten rakentamisessa, jotka pystyvät käsittelemään monimutkaisia vaatimuksia yritysympäristöissä.

## Oppimistavoitteet

Oppitunnin lopussa osaat:

- Toteuttaa monimodaalisia ominaisuuksia MCP-kehyksissä
- Suunnitella skaalautuvia MCP-arkkitehtuureja vaativiin käyttötapauksiin
- Soveltaa tietoturvan parhaita käytäntöjä MCP:n tietoturvaperiaatteiden mukaisesti
- Integroitu MCP yrityksen tekoälyjärjestelmiin ja kehyksiin
- Optimoida suorituskykyä ja luotettavuutta tuotantoympäristöissä

## Oppitunnit ja esimerkkiprojektit

| Linkki | Otsikko | Kuvaus |
|--------|---------|--------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrointi Azureen | Opi, miten integroida MCP-palvelimesi Azureen |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP monimodaaliset esimerkit | Esimerkkejä ääni-, kuva- ja monimodaalisista vastauksista |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalistinen Spring Boot -sovellus, joka näyttää OAuth2:n MCP:n kanssa sekä valtuutus- että resurssipalvelimena. Demonstroi turvallista tokenin myöntämistä, suojattuja päätepisteitä, Azure Container Apps -käyttöönottoa ja API Management -integraatiota. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root-kontekstit | Lisätietoa root-kontekstista ja sen toteuttamisesta |
| [5.5 Routing](./mcp-routing/README.md) | Reititys | Opi erilaisista reititystyypeistä |
| [5.6 Sampling](./mcp-sampling/README.md) | Otanta | Opi työskentelemään otannan kanssa |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaalaus | Opi skaalaamisesta |
| [5.8 Security](./mcp-security/README.md) | Tietoturva | Suojaa MCP-palvelimesi |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python-pohjainen MCP-palvelin ja asiakas, jotka integroituvat SerpAPI:in reaaliaikaista verkko-, uutis-, tuotehakua ja kysymys-vastaus -toimintoja varten. Demonstroi monityökalujen orkestrointia, ulkoisten API:en integraatiota ja vankkaa virheenkäsittelyä. |

## Lisäviitteet

Ajantasaisimman tiedon saamiseksi edistyneistä MCP-aiheista, tutustu:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Keskeiset opit

- Monimodaaliset MCP-toteutukset laajentavat tekoälyn kyvykkyyksiä tekstinkäsittelyn ulkopuolelle
- Skaalautuvuus on välttämätöntä yrityskäyttöönotossa ja sitä voidaan toteuttaa vaakasuunnassa ja pystysuunnassa skaalaamalla
- Laajat tietoturvatoimet suojaavat dataa ja varmistavat asianmukaisen pääsynhallinnan
- Yritysintegraatio alustojen kuten Azure OpenAI:n ja Microsoft AI Foundryn kanssa parantaa MCP:n toiminnallisuutta
- Edistyneet MCP-toteutukset hyötyvät optimoiduista arkkitehtuureista ja huolellisesta resurssien hallinnasta

## Harjoitus

Suunnittele yritystason MCP-toteutus tietylle käyttötapaukselle:

1. Määrittele monimodaaliset vaatimukset käyttötapauksellesi
2. Laadi tarvittavat tietoturvakontrollit arkaluonteisen datan suojaamiseksi
3. Suunnittele skaalautuva arkkitehtuuri, joka kestää vaihtelevan kuormituksen
4. Suunnittele integraatiopisteet yrityksen tekoälyjärjestelmiin
5. Dokumentoi mahdolliset suorituskyvyn pullonkaulat ja niiden lieventämisstrategiat

## Lisäresurssit

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Mitä seuraavaksi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ota huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.