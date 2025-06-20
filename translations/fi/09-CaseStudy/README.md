<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6c11b6162171abc895ed75d1e0f368a3",
  "translation_date": "2025-06-20T19:09:09+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "fi"
}
-->
# MCP käytännössä: Todellisia tapaustutkimuksia

Model Context Protocol (MCP) muuttaa tapaa, jolla tekoälysovellukset ovat vuorovaikutuksessa datan, työkalujen ja palveluiden kanssa. Tässä osiossa esitellään todellisia tapaustutkimuksia, jotka osoittavat MCP:n käytännön sovelluksia erilaisissa yritystilanteissa.

## Yleiskatsaus

Tässä osassa esitellään konkreettisia MCP-toteutuksia, jotka korostavat, miten organisaatiot hyödyntävät tätä protokollaa ratkaistakseen monimutkaisia liiketoiminnan haasteita. Tutustumalla näihin tapaustutkimuksiin saat käsityksen MCP:n monipuolisuudesta, skaalautuvuudesta ja käytännön hyödyistä todellisissa tilanteissa.

## Keskeiset oppimistavoitteet

Tutkimalla näitä tapaustutkimuksia opit:

- Miten MCP:tä voidaan käyttää tiettyjen liiketoimintaongelmien ratkaisemiseen
- Eri integraatiomalleista ja arkkitehtuurisista lähestymistavoista
- Parhaista käytännöistä MCP:n toteuttamisessa yritysympäristöissä
- Haasteista ja ratkaisuista, joita on kohdattu käytännön toteutuksissa
- Mahdollisuuksista soveltaa samanlaisia malleja omissa projekteissasi

## Esitellyt tapaustutkimukset

### 1. [Azure AI Travel Agents – Referenssitoteutus](./travelagentsample.md)

Tässä tapaustutkimuksessa tarkastellaan Microsoftin kattavaa referenssiratkaisua, joka näyttää, miten rakentaa moniagenttipohjainen, tekoälyllä toimiva matkasuunnittelusovellus MCP:n, Azure OpenAI:n ja Azure AI Searchin avulla. Projekti esittelee:

- Moniagenttien orkestroinnin MCP:n kautta
- Yritysdatan integroinnin Azure AI Searchin avulla
- Turvallisen ja skaalautuvan arkkitehtuurin Azure-palveluilla
- Laajennettavat työkalut uudelleenkäytettävillä MCP-komponenteilla
- Keskustelupohjaisen käyttökokemuksen, jota Azure OpenAI tukee

Arkkitehtuuri- ja toteutusyksityiskohdat tarjoavat arvokkaita näkemyksiä monimutkaisten moniagenttijärjestelmien rakentamisesta MCP:n koordinointikerroksena.

### 2. [Azure DevOps -kohteiden päivitys YouTube-datan perusteella](./UpdateADOItemsFromYT.md)

Tässä tapaustutkimuksessa demonstroidaan MCP:n käytännön sovellusta työnkulkujen automatisointiin. Se näyttää, miten MCP-työkaluja voidaan käyttää:

- Datan poimimiseen verkkoalustoilta (YouTube)
- Työkohteiden päivittämiseen Azure DevOps -järjestelmissä
- Toistettavien automaatiotyönkulkujen luomiseen
- Datan integrointiin eri järjestelmien välillä

Tämä esimerkki havainnollistaa, miten jopa suhteellisen yksinkertaiset MCP-toteutukset voivat tuoda merkittäviä tehokkuushyötyjä automatisoimalla rutiinitehtäviä ja parantamalla datan yhdenmukaisuutta järjestelmien välillä.

## Yhteenveto

Nämä tapaustutkimukset korostavat Model Context Protocolin monipuolisuutta ja käytännön sovelluksia todellisissa tilanteissa. Monimutkaisista moniagenttijärjestelmistä kohdennettuun automaatioon MCP tarjoaa standardoidun tavan yhdistää tekoälyjärjestelmät tarvitsemiinsa työkaluihin ja dataan tuottaakseen arvoa.

Tutkimalla näitä toteutuksia saat käsityksen arkkitehtuurimalleista, toteutusstrategioista ja parhaista käytännöistä, joita voit soveltaa omissa MCP-projekteissasi. Esimerkit osoittavat, että MCP ei ole pelkkä teoreettinen kehys, vaan käytännöllinen ratkaisu todellisiin liiketoiminnan haasteisiin.

## Lisäresurssit

- [Azure AI Travel Agents GitHub-repositorio](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP -työkalu](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP -työkalu](https://github.com/microsoft/playwright-mcp)
- [MCP-yhteisön esimerkit](https://github.com/microsoft/mcp)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulee pitää virallisena lähteenä. Tärkeiden tietojen osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.