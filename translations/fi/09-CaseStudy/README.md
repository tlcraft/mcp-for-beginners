<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-08-18T15:56:17+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "fi"
}
-->
# MCP toiminnassa: Käytännön esimerkkitapaukset

[![MCP toiminnassa: Käytännön esimerkkitapaukset](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.fi.png)](https://youtu.be/IxshWb2Az5w)

_(Klikkaa yllä olevaa kuvaa nähdäksesi tämän oppitunnin videon)_

Model Context Protocol (MCP) muuttaa tapaa, jolla tekoälysovellukset vuorovaikuttavat datan, työkalujen ja palveluiden kanssa. Tässä osiossa esitellään käytännön esimerkkitapauksia, jotka havainnollistavat MCP:n soveltamista erilaisissa yritysympäristöissä.

## Yleiskatsaus

Tämä osio esittelee konkreettisia MCP:n toteutuksia ja korostaa, kuinka organisaatiot hyödyntävät tätä protokollaa ratkaistakseen monimutkaisia liiketoiminnan haasteita. Näiden esimerkkitapausten avulla saat käsityksen MCP:n monipuolisuudesta, skaalautuvuudesta ja käytännön hyödyistä todellisissa tilanteissa.

## Keskeiset oppimistavoitteet

Näitä esimerkkitapauksia tutkimalla opit:

- Ymmärtämään, miten MCP:tä voidaan soveltaa tiettyjen liiketoimintaongelmien ratkaisemiseen
- Oppimaan erilaisia integraatiomalleja ja arkkitehtuurilähestymistapoja
- Tunnistamaan parhaat käytännöt MCP:n toteuttamisessa yritysympäristöissä
- Saamaan näkemyksiä haasteista ja ratkaisuista, joita todellisissa toteutuksissa on kohdattu
- Löytämään mahdollisuuksia soveltaa vastaavia malleja omissa projekteissasi

## Esimerkkitapaukset

### 1. [Azure AI Matka-agentit – Referenssitoteutus](./travelagentsample.md)

Tässä esimerkkitapauksessa tarkastellaan Microsoftin kattavaa referenssiratkaisua, joka osoittaa, miten rakentaa monen agentin, tekoälypohjainen matkan suunnittelusovellus MCP:n, Azure OpenAI:n ja Azure AI Searchin avulla. Projektissa esitellään:

- Monen agentin orkestrointi MCP:n avulla
- Yritysdataintegraatio Azure AI Searchin kanssa
- Turvallinen ja skaalautuva arkkitehtuuri Azure-palveluiden avulla
- Laajennettavat työkalut uudelleenkäytettävillä MCP-komponenteilla
- Keskustelupohjainen käyttäjäkokemus Azure OpenAI:n avulla

Arkkitehtuuri ja toteutuksen yksityiskohdat tarjoavat arvokkaita näkemyksiä monimutkaisten monen agentin järjestelmien rakentamisesta MCP:n koordinaatiokerroksena.

### 2. [Azure DevOps -kohteiden päivittäminen YouTube-datasta](./UpdateADOItemsFromYT.md)

Tämä esimerkkitapaus havainnollistaa MCP:n käytännön soveltamista työnkulkujen automatisointiin. Siinä näytetään, miten MCP-työkaluja voidaan käyttää:

- Datan poimimiseen verkkoplatformeista (YouTube)
- Työkohteiden päivittämiseen Azure DevOps -järjestelmissä
- Toistettavien automaatiotyönkulkujen luomiseen
- Datan integroimiseen eri järjestelmien välillä

Tämä esimerkki osoittaa, kuinka jopa suhteellisen yksinkertaiset MCP-toteutukset voivat tuoda merkittäviä tehokkuushyötyjä automatisoimalla rutiinitehtäviä ja parantamalla datan johdonmukaisuutta järjestelmien välillä.

### 3. [Reaaliaikainen dokumentaatiohaku MCP:n avulla](./docs-mcp/README.md)

Tämä esimerkkitapaus opastaa Python-konsoliklientin yhdistämisessä Model Context Protocol (MCP) -palvelimeen reaaliaikaisen, kontekstuaalisen Microsoft-dokumentaation hakemiseksi ja kirjaamiseksi. Opit:

- Yhdistämään MCP-palvelimeen Python-klientillä ja virallisella MCP SDK:lla
- Käyttämään suoratoistavia HTTP-klienttejä tehokkaaseen reaaliaikaiseen datan hakuun
- Kutsumaan dokumentaatiotyökaluja palvelimella ja kirjaamaan vastaukset suoraan konsoliin
- Integroimaan ajantasaisen Microsoft-dokumentaation työnkulkuusi ilman, että tarvitset siirtyä terminaalista

Luku sisältää käytännön tehtävän, minimaalisen toimivan koodiesimerkin ja linkkejä lisäresursseihin syvempää oppimista varten. Katso koko läpikäynti ja koodi linkitetyssä luvussa ymmärtääksesi, miten MCP voi muuttaa dokumentaation käyttöä ja kehittäjän tuottavuutta konsolipohjaisissa ympäristöissä.

### 4. [Interaktiivinen opintosuunnitelman luontisovellus MCP:n avulla](./docs-mcp/README.md)

Tämä esimerkkitapaus näyttää, miten rakentaa interaktiivinen verkkosovellus Chainlitin ja Model Context Protocol (MCP):n avulla henkilökohtaisten opintosuunnitelmien luomiseksi mihin tahansa aiheeseen. Käyttäjät voivat määrittää aiheen (esim. "AI-900-sertifikaatti") ja opiskeluajan (esim. 8 viikkoa), ja sovellus tarjoaa viikko viikolta jaotellut suositukset sisällöstä. Chainlit mahdollistaa keskustelupohjaisen chat-käyttöliittymän, joka tekee kokemuksesta mukaansatempaavan ja mukautuvan.

- Keskustelupohjainen verkkosovellus Chainlitin avulla
- Käyttäjän ohjaamat kehotteet aiheen ja keston määrittämiseksi
- Viikko viikolta sisältösuositukset MCP:n avulla
- Reaaliaikaiset, mukautuvat vastaukset chat-käyttöliittymässä

Projekti havainnollistaa, miten keskustelupohjainen tekoäly ja MCP voidaan yhdistää luomaan dynaamisia, käyttäjälähtöisiä oppimistyökaluja modernissa verkkoympäristössä.

### 5. [Editorissa näkyvät dokumentit MCP-palvelimen avulla VS Codessa](./docs-mcp/README.md)

Tämä esimerkkitapaus näyttää, miten voit tuoda Microsoft Learn -dokumentaation suoraan VS Code -ympäristöösi MCP-palvelimen avulla – ei enää selaimen välilehtien vaihtamista! Näet, miten:

- Etsi ja lue dokumentteja välittömästi VS Codessa MCP-paneelin tai komentopaletin avulla
- Viittaa dokumentaatioon ja lisää linkkejä suoraan README- tai kurssin markdown-tiedostoihin
- Käytä GitHub Copilotia ja MCP:tä yhdessä saumattomien, tekoälypohjaisten dokumentaatio- ja koodityönkulkujen luomiseksi
- Vahvista ja paranna dokumentaatiota reaaliaikaisella palautteella ja Microsoftin tarkkuudella
- Integroi MCP GitHub-työnkulkuihin jatkuvaa dokumentaation validointia varten

Toteutus sisältää:

- Esimerkin `.vscode/mcp.json`-konfiguraatiosta helppoa käyttöönottoa varten
- Kuvakaappauksiin perustuvat läpikäynnit editorikokemuksesta
- Vinkkejä Copilotin ja MCP:n yhdistämiseen maksimaalisen tuottavuuden saavuttamiseksi

Tämä skenaario sopii kurssin kirjoittajille, dokumentaation tekijöille ja kehittäjille, jotka haluavat pysyä keskittyneinä editorissaan työskennellessään dokumenttien, Copilotin ja validointityökalujen kanssa – kaikki MCP:n avulla.

### 6. [APIM MCP-palvelimen luominen](./apimsample.md)

Tämä esimerkkitapaus tarjoaa vaiheittaisen oppaan MCP-palvelimen luomisesta Azure API Managementin (APIM) avulla. Se kattaa:

- MCP-palvelimen perustamisen Azure API Managementissa
- API-toimintojen tarjoamisen MCP-työkaluina
- Politiikkojen konfiguroinnin rajoitusten ja turvallisuuden hallintaan
- MCP-palvelimen testaamisen Visual Studio Codessa ja GitHub Copilotilla

Tämä esimerkki havainnollistaa, miten hyödyntää Azuren ominaisuuksia luodaksesi vankan MCP-palvelimen, jota voidaan käyttää erilaisissa sovelluksissa, parantaen tekoälyjärjestelmien integraatiota yrityksen API:hin.

## Yhteenveto

Nämä esimerkkitapaukset korostavat Model Context Protocolin monipuolisuutta ja käytännön sovelluksia todellisissa tilanteissa. Monimutkaisista monen agentin järjestelmistä kohdennettuihin automaatiotyönkulkuihin MCP tarjoaa standardoidun tavan yhdistää tekoälyjärjestelmät työkaluihin ja dataan, joita ne tarvitsevat arvon tuottamiseen.

Tutkimalla näitä toteutuksia voit saada näkemyksiä arkkitehtuurimalleista, toteutusstrategioista ja parhaista käytännöistä, joita voit soveltaa omiin MCP-projekteihisi. Esimerkit osoittavat, että MCP ei ole pelkästään teoreettinen kehys, vaan käytännön ratkaisu todellisiin liiketoiminnan haasteisiin.

## Lisäresurssit

- [Azure AI Matka-agentit GitHub-repositorio](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP-työkalu](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP-työkalu](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP-palvelin](https://github.com/MicrosoftDocs/mcp)
- [MCP-yhteisön esimerkit](https://github.com/microsoft/mcp)

Seuraavaksi: Käytännön laboratorio [Tekoälytyönkulkujen tehostaminen: MCP-palvelimen rakentaminen AI Toolkitilla](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.