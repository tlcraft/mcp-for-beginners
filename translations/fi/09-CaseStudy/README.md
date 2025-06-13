<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "23899e82d806f25e5e46e89aab564dca",
  "translation_date": "2025-06-13T21:27:12+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "fi"
}
-->
# MCP käytännössä: todellisia tapaustutkimuksia

Model Context Protocol (MCP) muuttaa tapaa, jolla tekoälysovellukset ovat vuorovaikutuksessa datan, työkalujen ja palveluiden kanssa. Tässä osiossa esitellään todellisia tapaustutkimuksia, jotka havainnollistavat MCP:n käytännön sovelluksia erilaisissa yritystilanteissa.

## Yleiskatsaus

Tässä osiossa esitellään konkreettisia esimerkkejä MCP:n toteutuksista ja korostetaan, miten organisaatiot hyödyntävät tätä protokollaa ratkaistakseen monimutkaisia liiketoiminnan haasteita. Tarkastelemalla näitä tapaustutkimuksia saat käsityksen MCP:n monipuolisuudesta, skaalautuvuudesta ja käytännön hyödyistä todellisissa tilanteissa.

## Keskeiset oppimistavoitteet

Tutustumalla näihin tapaustutkimuksiin opit:

- Ymmärtämään, miten MCP:tä voidaan soveltaa tiettyjen liiketoimintaongelmien ratkaisemiseen
- Tutustumaan erilaisiin integraatiomalleihin ja arkkitehtuuriratkaisuihin
- Tunnistamaan parhaita käytäntöjä MCP:n käyttöönotossa yritysympäristöissä
- Saamaan näkemyksiä todellisissa toteutuksissa kohdatuista haasteista ja ratkaisuista
- Löytämään mahdollisuuksia soveltaa vastaavia malleja omissa projekteissasi

## Esitellyt tapaustutkimukset

### 1. [Azure AI Travel Agents – Reference Implementation](./travelagentsample.md)

Tässä tapaustutkimuksessa tarkastellaan Microsoftin kattavaa referenssiratkaisua, joka havainnollistaa, miten MCP:n, Azure OpenAI:n ja Azure AI Searchin avulla rakennetaan moniagenttinen tekoälypohjainen matkasuunnitteluohjelma. Projekti esittelee:

- Moniagenttien orkestroinnin MCP:n kautta
- Yritysdatan integroinnin Azure AI Searchilla
- Turvallisen ja skaalautuvan arkkitehtuurin Azure-palveluilla
- Laajennettavat työkalut uudelleenkäytettävillä MCP-komponenteilla
- Keskustelupohjaisen käyttäjäkokemuksen, jonka tarjoaa Azure OpenAI

Arkkitehtuuri ja toteutuksen yksityiskohdat tarjoavat arvokkaita näkemyksiä monimutkaisten moniagenttijärjestelmien rakentamisesta MCP:n koordinaatiokerroksena.

### 2. [Updating Azure DevOps Items from YouTube Data](./UpdateADOItemsFromYT.md)

Tämä tapaustutkimus osoittaa MCP:n käytännön sovelluksen työnkulkujen automatisointiin. Se näyttää, miten MCP-työkaluja voidaan käyttää:

- Datan poimimiseen verkkoplatformeilta (YouTube)
- Työkohteiden päivittämiseen Azure DevOps -järjestelmissä
- Toistettavien automaatiotyönkulkujen luomiseen
- Datan integroimiseen eri järjestelmien välillä

Tämä esimerkki havainnollistaa, kuinka jopa suhteellisen yksinkertaiset MCP-toteutukset voivat tuoda merkittäviä tehokkuushyötyjä automatisoimalla rutiinitehtäviä ja parantamalla datan yhdenmukaisuutta järjestelmien välillä.

## Yhteenveto

Nämä tapaustutkimukset korostavat Model Context Protocolin monipuolisuutta ja käytännön sovelluksia todellisissa tilanteissa. Monimutkaisista moniagenttijärjestelmistä kohdennettuun automaatioon MCP tarjoaa standardoidun tavan yhdistää tekoälyjärjestelmät tarvittaviin työkaluihin ja datoihin arvon tuottamiseksi.

Tutkimalla näitä toteutuksia saat näkemyksiä arkkitehtuurimalleista, toteutusstrategioista ja parhaista käytännöistä, joita voit soveltaa omissa MCP-projekteissasi. Esimerkit osoittavat, että MCP ei ole pelkästään teoreettinen kehys, vaan käytännön ratkaisu todellisiin liiketoiminnan haasteisiin.

## Lisäresurssit

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta ole hyvä ja huomioi, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä on pidettävä auktoritatiivisena lähteenä. Tärkeiden tietojen osalta suositellaan ammattilaisen tekemää ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkintojen seurauksista.