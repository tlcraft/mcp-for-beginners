<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:30:27+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "fi"
}
-->
# MCP-palvelimien käyttöönotto

MCP-palvelimen käyttöönotto mahdollistaa sen työkalujen ja resurssien käytön myös paikallisen ympäristösi ulkopuolella. Käyttöönottoon on useita strategioita, jotka kannattaa valita tarpeidesi mukaan, kuten skaalaavuuden, luotettavuuden ja hallinnan helppouden perusteella. Alla löydät ohjeita MCP-palvelimien käyttöönottoon paikallisesti, konteissa ja pilvessä.

## Yleiskatsaus

Tässä oppitunnissa käydään läpi MCP Server -sovelluksen käyttöönotto.

## Oppimistavoitteet

Oppitunnin lopuksi osaat:

- Arvioida erilaisia käyttöönoton tapoja.
- Ota sovelluksesi käyttöön.

## Paikallinen kehitys ja käyttöönotto

Jos palvelimesi on tarkoitettu käytettäväksi käyttäjän koneella, voit noudattaa seuraavia vaiheita:

1. **Lataa palvelin**. Jos et ole kirjoittanut palvelinta itse, lataa se ensin koneellesi.  
1. **Käynnistä palvelinprosessi**: Käynnistä MCP Server -sovelluksesi.

SSE:tä varten (ei tarvita stdio-tyyppiselle palvelimelle)

1. **Määritä verkkoasetukset**: Varmista, että palvelin on saavutettavissa odotetulla portilla.  
1. **Yhdistä asiakkaat**: Käytä paikallisia yhteysosoitteita kuten `http://localhost:3000`.

## Pilvikäyttöönotto

MCP-palvelimia voidaan ottaa käyttöön useilla pilvialustoilla:

- **Serverless Functions**: Ota käyttöön kevyitä MCP-palvelimia serverless-funktioina.  
- **Container Services**: Käytä palveluita kuten Azure Container Apps, AWS ECS tai Google Cloud Run.  
- **Kubernetes**: Ota MCP-palvelimet käyttöön ja hallinnoi niitä Kubernetes-klustereissa korkean käytettävyyden takaamiseksi.

### Esimerkki: Azure Container Apps

Azure Container Apps tukee MCP-palvelimien käyttöönottoa. Se on vielä kehitysvaiheessa, ja tällä hetkellä se tukee SSE-palvelimia.

Näin voit toimia:

1. Kloonaa repositorio:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Käynnistä se paikallisesti testataksesi:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Kokeillaksesi paikallisesti, luo *mcp.json* tiedosto *.vscode* -hakemistoon ja lisää seuraava sisältö:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  Kun SSE-palvelin on käynnistetty, voit klikata JSON-tiedostossa olevaa toistopainiketta. Tämän jälkeen GitHub Copilot tunnistaa palvelimen työkalut, katso työkalukuvaketta.

1. Käyttöönottoa varten suorita seuraava komento:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Siinäpä se, ota palvelin käyttöön paikallisesti tai Azureen näiden vaiheiden avulla.

## Lisäresurssit

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)  
- [Azure Container Apps -artikkeli](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)  
- [Azure Container Apps MCP -repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)  

## Mitä seuraavaksi

- Seuraava: [Practical Implementation](/04-PracticalImplementation/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai virhetulkinnoista.