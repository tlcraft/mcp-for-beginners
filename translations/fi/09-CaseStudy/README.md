<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T13:56:40+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "fi"
}
-->
# MCP toiminnassa: käytännön esimerkkitapauksia

Model Context Protocol (MCP) muuttaa tapaa, jolla tekoälysovellukset käyttävät dataa, työkaluja ja palveluita. Tässä osiossa esitellään käytännön esimerkkitapauksia, jotka havainnollistavat MCP:n soveltamista erilaisissa yritysympäristöissä.

## Yleiskatsaus

Tässä osiossa esitellään konkreettisia MCP-ratkaisujen toteutuksia, jotka korostavat, miten organisaatiot hyödyntävät tätä protokollaa ratkaistakseen monimutkaisia liiketoiminnan haasteita. Tarkastelemalla näitä esimerkkitapauksia saat näkemyksiä MCP:n monipuolisuudesta, skaalautuvuudesta ja käytännön hyödyistä todellisissa tilanteissa.

## Keskeiset oppimistavoitteet

Näitä esimerkkitapauksia tutkimalla opit:

- Miten MCP:tä voidaan soveltaa tiettyjen liiketoimintaongelmien ratkaisemiseen
- Eri integraatiomallit ja arkkitehtuuriset lähestymistavat
- Parhaat käytännöt MCP:n toteuttamiseen yritysympäristöissä
- Haasteet ja ratkaisut, joita todellisissa toteutuksissa on kohdattu
- Mahdollisuudet soveltaa samankaltaisia malleja omissa projekteissasi

## Esitellyt esimerkkitapaukset

### 1. [Azure AI Travel Agents – Referenssitoteutus](./travelagentsample.md)

Tässä esimerkkitapauksessa tarkastellaan Microsoftin kattavaa referenssiratkaisua, joka osoittaa, miten rakentaa moniagenttinen, tekoälyllä toimiva matkasuunnittelu­appi MCP:n, Azure OpenAI:n ja Azure AI Searchin avulla. Projekti esittelee:

- Moniagenttien orkestroinnin MCP:n kautta
- Yritysdatan integroinnin Azure AI Searchilla
- Turvallisen ja skaalautuvan arkkitehtuurin Azure-palveluilla
- Laajennettavat työkalut uudelleenkäytettävillä MCP-komponenteilla
- Keskustelukäyttöliittymän Azure OpenAI:n voimalla

Arkkitehtuuri ja toteutuksen yksityiskohdat tarjoavat arvokkaita näkemyksiä monimutkaisten moniagenttijärjestelmien rakentamisesta MCP:n koordinaatiokerroksena.

### 2. [Azure DevOps -kohteiden päivitys YouTube-datan perusteella](./UpdateADOItemsFromYT.md)

Tässä esimerkkitapauksessa demonstroidaan MCP:n käytännön sovellusta työnkulkujen automatisointiin. Näytetään, miten MCP-työkaluja voidaan käyttää:

- Datan poimintaan verkkopalveluista (YouTube)
- Työkohteiden päivittämiseen Azure DevOps -järjestelmissä
- Toistettavien automaatiotyönkulkujen luomiseen
- Datan integrointiin eri järjestelmien välillä

Tämä esimerkki havainnollistaa, miten jopa melko yksinkertaiset MCP-toteutukset voivat parantaa tehokkuutta automatisoimalla rutiinitehtäviä ja parantamalla datan yhdenmukaisuutta järjestelmien välillä.

### 3. [Reaaliaikainen dokumentaation haku MCP:llä](./docs-mcp/README.md)

Tässä esimerkkitapauksessa opastetaan Python-konsoliasiakkaan yhdistämisessä Model Context Protocol (MCP) -palvelimeen reaaliaikaisen, kontekstin huomioivan Microsoft-dokumentaation hakemiseksi ja lokittamiseksi. Opit:

- Yhdistämään MCP-palvelimeen Python-asiakkaalla ja virallisella MCP SDK:lla
- Käyttämään suoratoistavia HTTP-asiakkaita tehokkaaseen reaaliaikaiseen datan hakuun
- Kutsumaan dokumentaatiotyökaluja palvelimella ja kirjaamaan vastaukset suoraan konsoliin
- Integroimaan ajantasaisen Microsoft-dokumentaation työnkulkuusi ilman, että joudut poistumaan terminaalista

Luku sisältää käytännön harjoituksen, minimikoodiesimerkin ja linkkejä lisäresursseihin syvempää oppimista varten. Katso koko läpikäynti ja koodi linkitetystä luvusta ymmärtääksesi, miten MCP voi mullistaa dokumentaation saatavuuden ja kehittäjien tuottavuuden konsolipohjaisissa ympäristöissä.

### 4. [Interaktiivinen opintosuunnitelman generointisovellus MCP:llä](./docs-mcp/README.md)

Tässä esimerkkitapauksessa näytetään, miten rakentaa interaktiivinen web-sovellus Chainlitin ja Model Context Protocolin (MCP) avulla henkilökohtaisia opintosuunnitelmia varten mille tahansa aiheelle. Käyttäjät voivat määrittää aiheen (esim. "AI-900 -sertifiointi") ja opiskeluajan (esim. 8 viikkoa), ja sovellus tarjoaa viikkokohtaisen suositellun sisällön erittelyn. Chainlit mahdollistaa keskustelupohjaisen chat-käyttöliittymän, joka tekee kokemuksesta mukaansatempaavan ja mukautuvan.

- Keskustelupohjainen web-sovellus Chainlitin voimalla
- Käyttäjän ohjaamat aiheen ja keston valinnat
- Viikkokohtaiset sisältösuositukset MCP:n avulla
- Reaaliaikaiset, mukautuvat vastaukset chat-käyttöliittymässä

Projekti havainnollistaa, miten keskusteleva tekoäly ja MCP voidaan yhdistää luomaan dynaamisia, käyttäjälähtöisiä oppimistyökaluja nykyaikaisessa verkkoympäristössä.

### 5. [Dokumentaatio suoraan VS Codessa MCP-palvelimella](./docs-mcp/README.md)

Tässä esimerkkitapauksessa näytetään, miten voit tuoda Microsoft Learn -dokumentaation suoraan VS Code -ympäristöösi MCP-palvelimen avulla – ei enää selainvälilehtien vaihtelua! Näet, miten:

- Voit hakea ja lukea dokumentaatiota välittömästi VS Codessa MCP-paneelin tai komentopalettin kautta
- Viitata dokumentaatioon ja lisätä linkkejä suoraan README- tai kurssimarkdown-tiedostoihin
- Käyttää GitHub Copilotia ja MCP:tä yhdessä sujuvien, tekoälyllä tehostettujen dokumentaatio- ja koodityönkulkujen luomiseksi
- Vahvistaa ja parantaa dokumentaatiota reaaliaikaisella palautteella ja Microsoftin lähteistä tulevalla tarkkuudella
- Integroi MCP GitHub-työnkulkuihin jatkuvaa dokumentaation validointia varten

Toteutus sisältää:
- Esimerkkikonfiguraation `.vscode/mcp.json` helppoon käyttöönottoon
- Kuvapohjaiset ohjeet editorikokemuksen läpikäyntiin
- Vinkkejä Copilotin ja MCP:n yhdistämiseen maksimaalisen tuottavuuden saavuttamiseksi

Tämä skenaario sopii erinomaisesti kurssien tekijöille, dokumentaation kirjoittajille ja kehittäjille, jotka haluavat pysyä keskittyneinä editorissaan työskennellessään dokumentaation, Copilotin ja validointityökalujen kanssa – kaikki MCP:n voimalla.

## Yhteenveto

Nämä esimerkkitapaukset korostavat Model Context Protocolin monipuolisuutta ja käytännön sovelluksia todellisissa tilanteissa. Monimutkaisista moniagenttijärjestelmistä kohdennettuun automaatioon MCP tarjoaa standardoidun tavan yhdistää tekoälyjärjestelmät tarvitsemiinsa työkaluihin ja dataan arvon tuottamiseksi.

Näitä toteutuksia tutkimalla saat näkemyksiä arkkitehtuurimalleista, toteutusstrategioista ja parhaista käytännöistä, joita voit soveltaa omissa MCP-projekteissasi. Esimerkit osoittavat, että MCP ei ole pelkkä teoreettinen kehys, vaan käytännön ratkaisu todellisiin liiketoiminnan haasteisiin.

## Lisäresurssit

- [Azure AI Travel Agents GitHub-repositorio](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP -työkalu](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP -työkalu](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP -palvelin](https://github.com/MicrosoftDocs/mcp)
- [MCP-yhteisön esimerkit](https://github.com/microsoft/mcp)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää ensisijaisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.