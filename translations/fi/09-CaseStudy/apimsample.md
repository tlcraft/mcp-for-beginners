<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:33:30+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "fi"
}
-->
# Case Study: Paljasta REST API API Managementissa MCP-palvelimena

Azure API Management on palvelu, joka tarjoaa portin API-päätepisteidesi päälle. Se toimii niin, että Azure API Management toimii välityspalvelimena API:esi edessä ja voi päättää, mitä saapuville pyynnöille tehdään.

Sen avulla saat käyttöösi monia ominaisuuksia, kuten:

- **Turvallisuus**, voit käyttää kaikkea API-avaimista JWT:hen ja hallittuun identiteettiin.
- **Kutsujen rajoitus**, erinomainen ominaisuus, jonka avulla voit päättää, kuinka monta kutsua pääsee läpi tietyn aikayksikön aikana. Tämä auttaa varmistamaan, että kaikilla käyttäjillä on hyvä käyttökokemus ja että palvelusi ei kuormitu liikaa.
- **Skaalaus ja kuormantasapaino**. Voit määrittää useita päätepisteitä kuorman tasaamiseksi ja päättää, miten "kuormantasapaino" toteutetaan.
- **AI-ominaisuudet kuten semanttinen välimuisti**, token-rajoitukset ja token-valvonta sekä paljon muuta. Nämä ovat erinomaisia ominaisuuksia, jotka parantavat reagointikykyä ja auttavat hallitsemaan token-kulutusta. [Lue lisää tästä](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Miksi MCP + Azure API Management?

Model Context Protocol on nopeasti muodostumassa standardiksi agenttipohjaisille AI-sovelluksille ja työkalujen sekä datan yhdenmukaiselle esittämiselle. Azure API Management on luonnollinen valinta, kun tarvitset API:en "hallintaa". MCP-palvelimet integroituvat usein muihin API:hin ratkaistakseen pyyntöjä esimerkiksi työkaluille. Siksi Azure API Managementin ja MCP:n yhdistäminen on järkevää.

## Yleiskatsaus

Tässä erityistapauksessa opimme paljastamaan API-päätepisteet MCP-palvelimena. Näin voimme helposti tehdä näistä päätepisteistä osan agenttipohjaista sovellusta hyödyntäen samalla Azure API Managementin ominaisuuksia.

## Keskeiset ominaisuudet

- Valitset ne päätepistemetodit, jotka haluat paljastaa työkaluina.
- Lisäominaisuudet riippuvat siitä, mitä määrittelet API:n politiikkaosiossa. Tässä näytämme, miten voit lisätä kutsujen rajoituksen.

## Esivaihe: API:n tuonti

Jos sinulla on jo API Azure API Managementissa, hienoa, voit ohittaa tämän vaiheen. Muussa tapauksessa tutustu tähän linkkiin, [API:n tuonti Azure API Managementiin](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Paljasta API MCP-palvelimena

API-päätepisteiden paljastamiseksi seuraa näitä ohjeita:

1. Siirry Azure-portaaliin osoitteessa <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Siirry API Management -instanssiisi.

1. Valitse vasemman valikon kautta APIs > MCP Servers > + Create new MCP Server.

1. Valitse API-kohdasta REST API, jonka haluat paljastaa MCP-palvelimena.

1. Valitse yksi tai useampi API-toiminto, jotka haluat paljastaa työkaluina. Voit valita kaikki toiminnot tai vain tietyt.

    ![Valitse paljastettavat metodit](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Valitse **Create**.

1. Siirry valikosta kohtaan **APIs** ja **MCP Servers**, sinun pitäisi nähdä seuraavaa:

    ![Näet MCP-palvelimen pääikkunassa](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP-palvelin on luotu ja API-toiminnot on paljastettu työkaluina. MCP-palvelin näkyy MCP Servers -paneelissa. URL-sarake näyttää MCP-palvelimen päätepisteen, jota voit kutsua testaukseen tai asiakassovelluksessa.

## Valinnainen: Politiikkojen määrittäminen

Azure API Managementin keskeinen käsite on politiikat, joissa määritellään erilaisia sääntöjä päätepisteille, kuten kutsujen rajoitus tai semanttinen välimuisti. Nämä politiikat kirjoitetaan XML-muodossa.

Näin voit määrittää politiikan MCP-palvelimesi kutsujen rajoittamiseksi:

1. Portaalissa, APIs-kohdassa, valitse **MCP Servers**.

1. Valitse luomasi MCP-palvelin.

1. Vasemmasta valikosta MCP:n alta valitse **Policies**.

1. Politiikkamuokkaimessa lisää tai muokkaa politiikkoja, jotka haluat soveltaa MCP-palvelimen työkaluihin. Politiikat määritellään XML-muodossa. Esimerkiksi voit lisätä politiikan, joka rajoittaa kutsuja MCP-palvelimen työkaluihin (tässä esimerkissä 5 kutsua 30 sekunnissa per asiakas-IP-osoite). Tässä on XML, joka toteuttaa kutsujen rajoituksen:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Tässä kuva politiikkamuokkaimesta:

    ![Politiikkamuokkain](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Kokeile

Varmistetaan, että MCP-palvelimemme toimii odotetusti.

Tätä varten käytämme Visual Studio Codea ja GitHub Copilotia sen Agent-tilassa. Lisäämme MCP-palvelimen *mcp.json*-tiedostoon. Näin Visual Studio Code toimii agenttikykyisenä asiakkaana, ja loppukäyttäjät voivat kirjoittaa kehotteen ja olla vuorovaikutuksessa palvelimen kanssa.

Näin lisäät MCP-palvelimen Visual Studio Codeen:

1. Käytä komentopalettia ja valitse MCP: **Add Server** -komento.

1. Kun sinulta kysytään, valitse palvelintyyppi: **HTTP (HTTP tai Server Sent Events)**.

1. Syötä MCP-palvelimen URL API Managementissa. Esimerkki: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE-päätepiste) tai **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP-päätepiste), huomaa kuljetustavan ero `/sse` tai `/mcp`.

1. Syötä haluamasi palvelimen tunniste. Tämä ei ole kriittinen arvo, mutta auttaa muistamaan, mikä palvelininstanssi on kyseessä.

1. Valitse, tallennetaanko konfiguraatio työtilan asetuksiin vai käyttäjäasetuksiin.

  - **Työtilan asetukset** – Palvelinasetukset tallennetaan .vscode/mcp.json -tiedostoon, joka on käytettävissä vain nykyisessä työtilassa.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    tai jos valitset streaming HTTP:n kuljetustavaksi, se näyttää hieman erilaiselta:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Käyttäjäasetukset** – Palvelinasetukset lisätään globaaliin *settings.json* -tiedostoon ja ovat käytettävissä kaikissa työtiloissa. Konfiguraatio näyttää suunnilleen tältä:

    ![Käyttäjäasetukset](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Sinun täytyy myös lisätä konfiguraatioon otsikko varmistaaksesi, että autentikointi Azure API Managementia kohtaan toimii oikein. Käytössä on otsikko nimeltä **Ocp-Apim-Subscription-Key**.

    - Näin lisäät sen asetuksiin:

    ![Otsikon lisääminen autentikointiin](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), tämä aiheuttaa kehotteen, jossa kysytään API-avaimen arvoa, jonka löydät Azure-portaalista Azure API Management -instanssiltasi.

   - Jos haluat lisätä sen *mcp.json*-tiedostoon, voit tehdä sen näin:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Käytä Agent-tilaa

Nyt kun olemme valmiita joko asetuksissa tai *.vscode/mcp.json*-tiedostossa, kokeillaan.

Työkalukuvakkeen pitäisi näkyä näin, ja palvelimesi paljastamat työkalut listautuvat siihen:

![Palvelimen työkalut](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Klikkaa työkalukuvaketta, ja näet työkalulistan:

    ![Työkalut](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Kirjoita keskusteluun kehotus työkalun kutsumiseksi. Esimerkiksi, jos valitsit työkalun tilaustiedon hakemiseen, voit kysyä agentilta tilauksesta. Tässä esimerkki kehotteesta:

    ```text
    get information from order 2
    ```

    Näet nyt työkalukuvakkeen, joka pyytää jatkamaan työkalun kutsumista. Valitse jatkaaksesi työkalun suorittamista, ja näet tuloksen seuraavasti:

    ![Kehotteen tulos](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **näkemäsi tulos riippuu valitsemistasi työkaluista, mutta idea on, että saat tekstimuotoisen vastauksen kuten yllä**

## Viitteet

Näin voit oppia lisää:

- [Opas Azure API Managementista ja MCP:stä](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python-esimerkki: Suojaa etä-MCP-palvelimet Azure API Managementilla (kokeellinen)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP-asiakasvaltuutuslaboratorio](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Käytä Azure API Management -laajennusta VS Codessa API:en tuontiin ja hallintaan](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Rekisteröi ja löydä etä-MCP-palvelimia Azure API Centerissä](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Erinomainen repositorio, joka esittelee monia AI-ominaisuuksia Azure API Managementin kanssa
- [AI Gateway -työpajat](https://azure-samples.github.io/AI-Gateway/) Sisältää työpajoja Azure-portaalin käytöstä, erinomainen tapa aloittaa AI-ominaisuuksien arviointi.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.