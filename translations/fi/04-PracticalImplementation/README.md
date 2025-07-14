<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb1ab5c924f58cf75ef1732d474f008a",
  "translation_date": "2025-07-14T17:17:24+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "fi"
}
-->
# Käytännön toteutus

Käytännön toteutus on se vaihe, jossa Model Context Protocolin (MCP) voima konkretisoituu. Vaikka MCP:n teorian ja arkkitehtuurin ymmärtäminen on tärkeää, todellinen arvo syntyy, kun sovellat näitä käsitteitä rakentaaksesi, testataksesi ja ottaaksesi käyttöön ratkaisuja, jotka ratkaisevat todellisia ongelmia. Tämä luku yhdistää käsitteellisen tiedon ja käytännön kehityksen, ohjaten sinua MCP-pohjaisten sovellusten toteuttamisessa.

Olitpa sitten kehittämässä älykkäitä avustajia, integroimassa tekoälyä liiketoimintaprosesseihin tai rakentamassa räätälöityjä työkaluja datankäsittelyyn, MCP tarjoaa joustavan perustan. Sen kieliriippumaton rakenne ja viralliset SDK:t suosituimmille ohjelmointikielille tekevät siitä helposti lähestyttävän monenlaisille kehittäjille. Hyödyntämällä näitä SDK:ita voit nopeasti prototyypittää, kehittää ja skaalata ratkaisuja eri alustoilla ja ympäristöissä.

Seuraavissa osioissa löydät käytännön esimerkkejä, koodinäytteitä ja käyttöönotto-strategioita, jotka näyttävät, miten MCP toteutetaan C#:lla, Javalla, TypeScriptillä, JavaScriptillä ja Pythonilla. Opit myös, miten MCP-palvelimia virheenkorjataan ja testataan, hallitaan API-rajapintoja ja otetaan ratkaisuja käyttöön pilvessä Azurea hyödyntäen. Nämä käytännön materiaalit on suunniteltu nopeuttamaan oppimistasi ja auttamaan sinua rakentamaan luotettavia, tuotantovalmiita MCP-sovelluksia.

## Yleiskatsaus

Tämä oppitunti keskittyy MCP:n käytännön toteutukseen useilla ohjelmointikielillä. Tutkimme, miten MCP SDK:ita käytetään C#:ssa, Javassa, TypeScriptissä, JavaScriptissä ja Pythonissa vahvojen sovellusten rakentamiseen, MCP-palvelimien virheenkorjaukseen ja testaukseen sekä uudelleenkäytettävien resurssien, kehotteiden ja työkalujen luomiseen.

## Oppimistavoitteet

Oppitunnin lopussa osaat:
- Toteuttaa MCP-ratkaisuja virallisten SDK:iden avulla eri ohjelmointikielillä
- Virheenkorjata ja testata MCP-palvelimia järjestelmällisesti
- Luoda ja käyttää palvelimen ominaisuuksia (Resurssit, Kehotteet ja Työkalut)
- Suunnitella tehokkaita MCP-työnkulkuja monimutkaisiin tehtäviin
- Optimoida MCP-toteutuksia suorituskyvyn ja luotettavuuden kannalta

## Viralliset SDK-resurssit

Model Context Protocol tarjoaa viralliset SDK:t useille kielille:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK:iden käyttö

Tässä osiossa on käytännön esimerkkejä MCP:n toteutuksesta useilla ohjelmointikielillä. Löydät esimerkkikoodit `samples`-hakemistosta, joka on järjestetty kielittäin.

### Saatavilla olevat esimerkit

Repositorio sisältää [esimerkkitoteutuksia](../../../04-PracticalImplementation/samples) seuraavilla kielillä:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Jokainen esimerkki havainnollistaa keskeisiä MCP-käsitteitä ja toteutusmalleja kyseiselle kielelle ja ekosysteemille.

## Palvelimen ydintoiminnot

MCP-palvelimet voivat toteuttaa minkä tahansa yhdistelmän seuraavista ominaisuuksista:

### Resurssit
Resurssit tarjoavat kontekstia ja dataa käyttäjälle tai tekoälymallille:
- Dokumenttivarastot
- Tietopohjat
- Rakenteelliset tietolähteet
- Tiedostojärjestelmät

### Kehotteet
Kehotteet ovat mallipohjaisia viestejä ja työnkulkuja käyttäjille:
- Ennalta määritellyt keskustelumallit
- Ohjatut vuorovaikutuskuviot
- Erikoistuneet dialogirakenteet

### Työkalut
Työkalut ovat toimintoja, joita tekoälymalli voi suorittaa:
- Datan käsittelyyn liittyvät apuvälineet
- Ulkoiset API-integraatiot
- Laskentakyvyt
- Hakutoiminnot

## Esimerkkitoteutukset: C#

Virallinen C# SDK -repositorio sisältää useita esimerkkitoteutuksia, jotka havainnollistavat MCP:n eri osa-alueita:

- **Perus MCP Client**: Yksinkertainen esimerkki MCP-asiakkaan luomisesta ja työkalujen kutsumisesta
- **Perus MCP Server**: Minimipalvelimen toteutus perus työkalujen rekisteröinnillä
- **Edistynyt MCP Server**: Täysimittainen palvelin työkalujen rekisteröinnillä, autentikoinnilla ja virheenkäsittelyllä
- **ASP.NET-integraatio**: Esimerkkejä ASP.NET Core -integraatiosta
- **Työkalujen toteutusmallit**: Erilaisia malleja työkalujen toteuttamiseen eri monimutkaisuustasoilla

MCP C# SDK on esikatseluvaiheessa, ja API:t voivat muuttua. Päivitämme tätä blogia jatkuvasti SDK:n kehittyessä.

### Keskeiset ominaisuudet
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Rakentaminen [ensimmäinen MCP-palvelimesi](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Täydelliset C# toteutusesimerkit löytyvät [virallisesta C# SDK -esimerkkirepositoriosta](https://github.com/modelcontextprotocol/csharp-sdk)

## Esimerkkitoteutus: Java

Java SDK tarjoaa vahvat MCP-toteutusmahdollisuudet yritystason ominaisuuksilla.

### Keskeiset ominaisuudet

- Spring Framework -integraatio
- Vahva tyyppiturvallisuus
- Reaktiivisen ohjelmoinnin tuki
- Laaja virheenkäsittely

Täydellinen Java-esimerkki löytyy [Java-esimerkistä](samples/java/containerapp/README.md) samples-hakemistosta.

## Esimerkkitoteutus: JavaScript

JavaScript SDK tarjoaa kevyen ja joustavan tavan toteuttaa MCP.

### Keskeiset ominaisuudet

- Node.js- ja selainympäristöjen tuki
- Promise-pohjainen API
- Helppo integraatio Expressin ja muiden kehysten kanssa
- WebSocket-tuki suoratoistoon

Täydellinen JavaScript-esimerkki löytyy [JavaScript-esimerkistä](samples/javascript/README.md) samples-hakemistosta.

## Esimerkkitoteutus: Python

Python SDK tarjoaa pythonmaisen tavan toteuttaa MCP erinomaisilla ML-kehysintegraatioilla.

### Keskeiset ominaisuudet

- Async/await-tuki asyncio-kirjastolla
- FastAPI-integraatio
- Yksinkertainen työkalujen rekisteröinti
- Natiivi integraatio suosittuihin ML-kirjastoihin

Täydellinen Python-esimerkki löytyy [Python-esimerkistä](samples/python/README.md) samples-hakemistosta.

## API-hallinta

Azure API Management on erinomainen ratkaisu MCP-palvelimien suojaamiseen. Ajatuksena on sijoittaa Azure API Management -instanssi MCP-palvelimesi eteen ja antaa sen hoitaa ominaisuuksia, joita todennäköisesti tarvitset, kuten:

- nopeusrajoitus
- tokenien hallinta
- valvonta
- kuormantasapainotus
- turvallisuus

### Azure-esimerkki

Tässä on Azure-esimerkki, joka tekee juuri tämän, eli [luo MCP-palvelimen ja suojaa sen Azure API Managementilla](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Katso, miten valtuutusprosessi tapahtuu alla olevassa kuvassa:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Edellä olevassa kuvassa tapahtuu seuraavaa:

- Todennus/valtuutus tapahtuu Microsoft Entran avulla.
- Azure API Management toimii porttina ja käyttää politiikkoja liikenteen ohjaukseen ja hallintaan.
- Azure Monitor kirjaa kaikki pyynnöt jatkoanalyysiä varten.

#### Valtuutusprosessi

Katsotaan valtuutusprosessia tarkemmin:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP-valtuutuksen määrittely

Lue lisää [MCP Authorization -määrittelystä](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Etä-MCP-palvelimen käyttöönotto Azureen

Katsotaan, voimmeko ottaa käyttöön aiemmin mainitun esimerkin:

1. Kloonaa repositorio

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Rekisteröi `Microsoft.App` -resurssin tarjoaja.
    * Jos käytät Azure CLI:tä, suorita `az provider register --namespace Microsoft.App --wait`.
    * Jos käytät Azure PowerShelliä, suorita `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Tarkista rekisteröinnin tila komennolla `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` hetken kuluttua.

2. Suorita tämä [azd](https://aka.ms/azd) -komento varmistamaan API Management -palvelu, funktiosovellus (koodin kanssa) ja kaikki muut tarvittavat Azure-resurssit

    ```shell
    azd up
    ```

    Tämä komento ottaa käyttöön kaikki pilviresurssit Azureen

### Palvelimen testaus MCP Inspectorilla

1. Avaa **uusi komentorivipääte** ja asenna sekä käynnistä MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Näet käyttöliittymän, joka näyttää tältä:

    ![Connect to Node inspector](/03-GettingStarted/01-first-server/assets/connect.png) 

1. CTRL-klikkaa ladataksesi MCP Inspector -verkkosovelluksen sovelluksen näyttämästä URL-osoitteesta (esim. http://127.0.0.1:6274/#resources)
1. Aseta siirtotavaksi `SSE`
1. Aseta URL osoittamaan käynnissä olevan API Managementin SSE-päätteeseen, joka näkyy `azd up` -komennon jälkeen, ja **Yhdistä**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listaa työkalut**. Klikkaa työkalua ja valitse **Suorita työkalu**.

Jos kaikki vaiheet onnistuivat, olet nyt yhteydessä MCP-palvelimeen ja olet pystynyt kutsumaan työkalua.

## MCP-palvelimet Azureen

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Tämä kokoelma repositorioita on pika-aloitusmalli räätälöityjen etä-MCP (Model Context Protocol) -palvelimien rakentamiseen ja käyttöönottoon Azure Functions -ympäristössä Pythonilla, C# .NET:llä tai Node/TypeScriptillä.

Esimerkit tarjoavat täydellisen ratkaisun, joka mahdollistaa kehittäjille:

- Paikallisen rakentamisen ja ajon: MCP-palvelimen kehittäminen ja virheenkorjaus paikallisella koneella
- Pilveen käyttöönoton: Helppo pilvikäyttöönotto yksinkertaisella azd up -komennolla
- Yhteyden asiakkaista: Yhteys MCP-palvelimeen eri asiakasohjelmista, mukaan lukien VS Coden Copilot agent -tila ja MCP Inspector -työkalu

### Keskeiset ominaisuudet:

- Turvallisuus suunnittelusta lähtien: MCP-palvelin on suojattu avaimilla ja HTTPS:llä
- Autentikointivaihtoehdot: Tukee OAuth:ta sisäänrakennetulla autentikoinnilla ja/tai API Managementilla
- Verkkoympäristön eristäminen: Mahdollistaa verkkoeristyksen Azure Virtual Networks (VNET) avulla
- Serverless-arkkitehtuuri: Hyödyntää Azure Functionsia skaalautuvaan, tapahtumapohjaiseen suoritukseen
- Paikallinen kehitys: Laaja tuki paikalliselle kehitykselle ja virheenkorjaukselle
- Yksinkertainen käyttöönotto: Virtaviivainen käyttöönotto Azureen

Repositoriossa on kaikki tarvittavat konfiguraatiotiedostot, lähdekoodi ja infrastruktuurin määrittelyt, jotta pääset nopeasti alkuun tuotantovalmiin MCP-palvelimen toteutuksessa.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - MCP:n esimerkkitoteutus Azure Functionsilla Pythonilla

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - MCP:n esimerkkitoteutus Azure Functionsilla C# .NET:llä

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - MCP:n esimerkkitoteutus Azure Functionsilla Node/TypeScriptillä.

## Keskeiset opit

- MCP SDK:t tarjoavat kielikohtaisia työkaluja vahvojen MCP-ratkaisujen toteutukseen
- Virheenkorjaus ja testaus ovat kriittisiä luotettaville MCP-sovelluksille
- Uudelleenkäytettävät kehotemallit mahdollistavat johdonmukaiset tekoälyvuorovaikutukset
- Hyvin suunnitellut työnkulut voivat orkestroida monimutkaisia tehtäviä useilla työkaluilla
- MCP-ratkaisujen toteutuksessa on huomioitava turvallisuus, suorituskyky ja virheenkäsittely

## Harjoitus

Suunnittele käytännön MCP-työnkulku, joka ratkaisee todellisen ongelman omalla alallasi:

1. Tunnista 3-4 työkalua, jotka olisivat hyödyllisiä ongelman ratkaisemisessa
2. Laadi työnkulun kaavio, joka näyttää, miten nämä työkalut ovat vuorovaikutuksessa
3. Toteuta perusversio yhdestä työkaluista valitsemallasi kielellä
4. Luo kehotemalli, joka auttaa mallia käyttämään työkalua tehokkaasti

## Lisäresurssit


---

Seuraava: [Edistyneet aiheet](../05-AdvancedTopics/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.