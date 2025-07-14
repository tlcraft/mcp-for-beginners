<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-14T05:47:59+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "fi"
}
-->
# MCP käytännössä: Todellisia tapaustutkimuksia

Model Context Protocol (MCP) muuttaa tapaa, jolla tekoälysovellukset ovat vuorovaikutuksessa datan, työkalujen ja palveluiden kanssa. Tässä osiossa esitellään todellisia tapaustutkimuksia, jotka havainnollistavat MCP:n käytännön sovelluksia erilaisissa yritysympäristöissä.

## Yleiskatsaus

Tässä osiossa esitellään konkreettisia esimerkkejä MCP:n toteutuksista, korostaen, miten organisaatiot hyödyntävät tätä protokollaa ratkaistakseen monimutkaisia liiketoiminnan haasteita. Tutustumalla näihin tapaustutkimuksiin saat käsityksen MCP:n monipuolisuudesta, skaalautuvuudesta ja käytännön hyödyistä todellisissa tilanteissa.

## Keskeiset oppimistavoitteet

Tutkimalla näitä tapaustutkimuksia opit:

- Miten MCP:tä voidaan soveltaa tiettyjen liiketoimintaongelmien ratkaisemiseen
- Eri integraatiomalleista ja arkkitehtonisista lähestymistavoista
- Parhaista käytännöistä MCP:n toteuttamisessa yritysympäristöissä
- Haasteista ja ratkaisuista, joita todellisissa toteutuksissa on kohdattu
- Mahdollisuuksista soveltaa samanlaisia malleja omissa projekteissasi

## Esitellyt tapaustutkimukset

### 1. [Azure AI Travel Agents – Referenssitoteutus](./travelagentsample.md)

Tässä tapaustutkimuksessa tarkastellaan Microsoftin kattavaa referenssiratkaisua, joka näyttää, miten rakentaa moniagenttinen, tekoälyllä toimiva matkasuunnittelu-sovellus käyttäen MCP:tä, Azure OpenAI:ta ja Azure AI Searchia. Projekti esittelee:

- Moniagenttien orkestroinnin MCP:n avulla
- Yritysdatan integroinnin Azure AI Searchin kautta
- Turvallisen ja skaalautuvan arkkitehtuurin Azure-palveluilla
- Laajennettavat työkalut uudelleenkäytettävillä MCP-komponenteilla
- Keskustelupohjaisen käyttäjäkokemuksen Azure OpenAI:n voimin

Arkkitehtuuri ja toteutuksen yksityiskohdat tarjoavat arvokkaita näkemyksiä monimutkaisten moniagenttijärjestelmien rakentamisesta MCP:n koordinaatiokerroksena.

### 2. [Azure DevOps -kohteiden päivitys YouTube-datan avulla](./UpdateADOItemsFromYT.md)

Tässä tapaustutkimuksessa havainnollistetaan MCP:n käytännön sovellus työnkulkujen automatisointiin. Se näyttää, miten MCP-työkaluja voidaan käyttää:

- Datan poimimiseen verkkopalveluista (YouTube)
- Työkohteiden päivittämiseen Azure DevOps -järjestelmissä
- Toistettavien automaatiotyönkulkujen luomiseen
- Datan integrointiin eri järjestelmien välillä

Tämä esimerkki osoittaa, miten jopa suhteellisen yksinkertaiset MCP-toteutukset voivat tuoda merkittäviä tehokkuushyötyjä automatisoimalla rutiinitehtäviä ja parantamalla datan yhdenmukaisuutta järjestelmien välillä.

### 3. [Reaaliaikainen dokumentaation haku MCP:llä](./docs-mcp/README.md)

Tässä tapaustutkimuksessa opastetaan, miten Python-konsoliasiakas yhdistetään Model Context Protocol (MCP) -palvelimeen reaaliaikaisen, kontekstin huomioivan Microsoft-dokumentaation hakemiseksi ja kirjaamiseksi. Opit:

- Yhdistämään MCP-palvelimeen Python-asiakkaalla ja virallisella MCP SDK:lla
- Käyttämään suoratoistavia HTTP-asiakkaita tehokkaaseen, reaaliaikaiseen datan hakuun
- Kutsumaan dokumentaatiotyökaluja palvelimella ja kirjaamaan vastaukset suoraan konsoliin
- Integroimaan ajantasaisen Microsoft-dokumentaation työnkulkuusi ilman, että tarvitsee poistua terminaalista

Luku sisältää käytännön harjoituksen, minimikoodiesimerkin ja linkkejä lisäresursseihin syvempää oppimista varten. Katso koko läpikäynti ja koodi linkitetyssä luvussa ymmärtääksesi, miten MCP voi muuttaa dokumentaation saatavuutta ja kehittäjien tuottavuutta konsolipohjaisissa ympäristöissä.

### 4. [Interaktiivinen opintosuunnitelman generaattori web-sovellus MCP:llä](./docs-mcp/README.md)

Tässä tapaustutkimuksessa näytetään, miten rakentaa interaktiivinen web-sovellus Chainlitin ja Model Context Protocolin (MCP) avulla, joka luo henkilökohtaisia opintosuunnitelmia mille tahansa aiheelle. Käyttäjät voivat määrittää aiheen (esim. "AI-900 -sertifiointi") ja opiskeluajan (esim. 8 viikkoa), ja sovellus tarjoaa viikkokohtaisen suositellun sisällön erittelyn. Chainlit mahdollistaa keskustelupohjaisen chat-käyttöliittymän, joka tekee kokemuksesta mukaansatempaavan ja mukautuvan.

- Keskustelupohjainen web-sovellus Chainlitin voimin
- Käyttäjän ohjaamat aiheen ja keston syötteet
- Viikkokohtaiset sisältösuositukset MCP:n avulla
- Reaaliaikaiset, mukautuvat vastaukset chat-käyttöliittymässä

Projekti havainnollistaa, miten keskusteleva tekoäly ja MCP voidaan yhdistää luomaan dynaamisia, käyttäjälähtöisiä opetustyökaluja nykyaikaisessa web-ympäristössä.

### 5. [Editorin sisäinen dokumentaatio MCP-palvelimella VS Codessa](./docs-mcp/README.md)

Tässä tapaustutkimuksessa näytetään, miten Microsoft Learn Docs voidaan tuoda suoraan VS Code -ympäristöön MCP-palvelimen avulla – ei enää selaimen välilehtien vaihtelua! Näet, miten:

- Dokumentaatiota voi hakea ja lukea välittömästi VS Codessa MCP-paneelin tai komentopalettin kautta
- Viitata dokumentaatioon ja lisätä linkkejä suoraan README- tai kurssin markdown-tiedostoihin
- Käyttää GitHub Copilotia ja MCP:tä saumattomasti yhdessä tekoälypohjaisissa dokumentaatio- ja koodityönkuluissa
- Varmistaa ja parantaa dokumentaatiota reaaliaikaisella palautteella ja Microsoftin tarjoamalla tarkkuudella
- Integroi MCP GitHub-työnkulkuihin jatkuvaa dokumentaation validointia varten

Toteutus sisältää:
- Esimerkkikonfiguraation `.vscode/mcp.json` helppoa käyttöönottoa varten
- Kuvakaappauspohjaiset läpikäynnit editorin sisäisestä kokemuksesta
- Vinkkejä Copilotin ja MCP:n yhdistämiseen maksimaalisen tuottavuuden saavuttamiseksi

Tämä skenaario sopii erinomaisesti kurssien tekijöille, dokumentaation kirjoittajille ja kehittäjille, jotka haluavat pysyä keskittyneinä editorissaan työskennellessään dokumentaation, Copilotin ja validointityökalujen kanssa – kaikki MCP:n voimin.

### 6. [APIM MCP -palvelimen luominen](./apimsample.md)

Tässä tapaustutkimuksessa annetaan vaiheittainen opas MCP-palvelimen luomiseen Azure API Managementin (APIM) avulla. Käsitellään:

- MCP-palvelimen perustaminen Azure API Managementiin
- API-toimintojen avaaminen MCP-työkaluina
- Politiikkojen määrittäminen nopeusrajoituksille ja turvallisuudelle
- MCP-palvelimen testaaminen Visual Studio Coden ja GitHub Copilotin avulla

Tämä esimerkki havainnollistaa, miten Azuren ominaisuuksia voidaan hyödyntää vahvan MCP-palvelimen luomiseksi, jota voidaan käyttää erilaisissa sovelluksissa tekoälyjärjestelmien integroinnin tehostamiseksi yrityksen API:hin.

## Yhteenveto

Nämä tapaustutkimukset korostavat Model Context Protocolin monipuolisuutta ja käytännön sovelluksia todellisissa tilanteissa. Monimutkaisista moniagenttijärjestelmistä kohdennettuun automaatioon MCP tarjoaa standardoidun tavan yhdistää tekoälyjärjestelmät tarvitsemiinsa työkaluihin ja dataan arvon tuottamiseksi.

Tutkimalla näitä toteutuksia saat näkemyksiä arkkitehtonisista malleista, toteutusstrategioista ja parhaista käytännöistä, joita voit soveltaa omissa MCP-projekteissasi. Esimerkit osoittavat, että MCP ei ole pelkkä teoreettinen kehys, vaan käytännön ratkaisu todellisiin liiketoiminnan haasteisiin.

## Lisäresurssit

- [Azure AI Travel Agents GitHub-repositorio](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Seuraava: Hands on Lab [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.