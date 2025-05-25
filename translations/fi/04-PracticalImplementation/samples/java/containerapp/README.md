<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e5ea5e7582f70008ea9bec3b3820f20a",
  "translation_date": "2025-05-17T14:28:18+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/README.md",
  "language_code": "fi"
}
-->
## Järjestelmän arkkitehtuuri

Tämä projekti esittelee verkkosovelluksen, joka käyttää sisällön turvallisuuden tarkistusta ennen kuin käyttäjän syötteet välitetään laskinpalveluun Model Context Protocol (MCP) -protokollan kautta.

### Kuinka se toimii

1. **Käyttäjän syöte**: Käyttäjä syöttää laskupyyntöä verkkokäyttöliittymässä
2. **Sisällön turvallisuustarkistus (syöte)**: Pyyntö analysoidaan Azure Content Safety API:n avulla
3. **Turvallisuuspäätös (syöte)**:
   - Jos sisältö on turvallista (vakavuus < 2 kaikissa kategorioissa), se jatkaa laskimeen
   - Jos sisältö merkitään mahdollisesti haitalliseksi, prosessi pysähtyy ja palauttaa varoituksen
4. **Laskimen integrointi**: Turvallinen sisältö käsitellään LangChain4j:n avulla, joka kommunikoi MCP-laskinpalvelimen kanssa
5. **Sisällön turvallisuustarkistus (tulos)**: Botin vastaus analysoidaan Azure Content Safety API:n avulla
6. **Turvallisuuspäätös (tulos)**:
   - Jos botin vastaus on turvallinen, se näytetään käyttäjälle
   - Jos botin vastaus merkitään mahdollisesti haitalliseksi, se korvataan varoituksella
7. **Vastaus**: Tulokset (jos turvallisia) näytetään käyttäjälle yhdessä molempien turvallisuusanalyysien kanssa

## Model Context Protocol (MCP) -protokollan käyttäminen laskinpalveluiden kanssa

Tämä projekti esittelee, kuinka käyttää Model Context Protocol (MCP) -protokollaa LangChain4j:n avulla kutsumaan laskinpalveluita. Toteutus käyttää paikallista MCP-palvelinta, joka toimii portissa 8080 tarjoten laskutoimituksia.

### Azure Content Safety -palvelun asettaminen

Ennen kuin käytät sisällön turvallisuusominaisuuksia, sinun tulee luoda Azure Content Safety -palveluresurssi:

1. Kirjaudu [Azure-portaaliin](https://portal.azure.com)
2. Klikkaa "Luo resurssi" ja etsi "Content Safety"
3. Valitse "Content Safety" ja klikkaa "Luo"
4. Anna resurssillesi yksilöllinen nimi
5. Valitse tilauksesi ja resurssiryhmäsi (tai luo uusi)
6. Valitse tuettu alue (katso [Alueen saatavuus](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=cognitive-services) yksityiskohdat)
7. Valitse sopiva hinnoittelutaso
8. Klikkaa "Luo" resurssin käyttöönottoon
9. Kun käyttöönotto on valmis, klikkaa "Siirry resurssiin"
10. Vasemmassa paneelissa, kohdassa "Resurssien hallinta", valitse "Avaimet ja päätepiste"
11. Kopioi jompikumpi avaimista ja päätepisteen URL seuraavaa vaihetta varten

### Ympäristömuuttujien konfigurointi

Aseta `GITHUB_TOKEN` ympäristömuuttuja GitHub-mallien autentikointia varten:
```sh
export GITHUB_TOKEN=<your_github_token>
```

Sisällön turvallisuusominaisuuksia varten aseta:
```sh
export CONTENT_SAFETY_ENDPOINT=<your_content_safety_endpoint>
export CONTENT_SAFETY_KEY=<your_content_safety_key>
```

Nämä ympäristömuuttujat käytetään sovelluksessa autentikoitumiseen Azure Content Safety -palvelun kanssa. Jos näitä muuttujia ei aseteta, sovellus käyttää paikkamerkkiarvoja demonstraatiotarkoituksiin, mutta sisällön turvallisuusominaisuudet eivät toimi kunnolla.

### Laskimen MCP-palvelimen käynnistäminen

Ennen kuin suoritat asiakkaan, sinun tulee käynnistää laskimen MCP-palvelin SSE-tilassa localhost:8080:ssa.

## Projektin kuvaus

Tämä projekti esittelee Model Context Protocol (MCP) -protokollan integroinnin LangChain4j:n kanssa laskinpalveluiden kutsumiseen. Keskeisiä ominaisuuksia ovat:

- MCP:n käyttäminen laskinpalveluun yhdistämiseen perusmatemaattisia operaatioita varten
- Kaksikerroksinen sisällön turvallisuustarkistus sekä käyttäjän syötteille että botin vastauksille
- Integrointi GitHubin gpt-4.1-nano-mallin kanssa LangChain4j:n kautta
- Server-Sent Events (SSE) -tapahtumien käyttäminen MCP-kuljetukseen

## Sisällön turvallisuuden integrointi

Projekti sisältää kattavat sisällön turvallisuusominaisuudet varmistaakseen, että sekä käyttäjän syötteet että järjestelmän vastaukset ovat vapaita haitallisesta sisällöstä:

1. **Syötteen tarkistus**: Kaikki käyttäjän pyynnöt analysoidaan haitallisten sisältökategorioiden, kuten vihapuheen, väkivallan, itsensä vahingoittamisen ja seksuaalisen sisällön, varalta ennen käsittelyä.

2. **Tuloksen tarkistus**: Vaikka käytettäisiin mahdollisesti sensuroimattomia malleja, järjestelmä tarkistaa kaikki luodut vastaukset samojen sisällön turvallisuussuodattimien avulla ennen kuin ne näytetään käyttäjälle.

Tämä kaksikerroksinen lähestymistapa varmistaa, että järjestelmä pysyy turvallisena riippumatta siitä, mitä AI-mallia käytetään, suojaten käyttäjiä sekä haitallisilta syötteiltä että mahdollisesti ongelmallisilta AI-luoduilta tuloksilta.

## Verkkoklientti

Sovellus sisältää käyttäjäystävällisen verkkokäyttöliittymän, jonka avulla käyttäjät voivat olla vuorovaikutuksessa Content Safety Calculator -järjestelmän kanssa:

### Verkkokäyttöliittymän ominaisuudet

- Yksinkertainen, intuitiivinen lomake laskupyyntöjen syöttämiseen
- Kaksikerroksinen sisällön turvallisuuden validointi (syöte ja tulos)
- Reaaliaikainen palaute pyynnön ja vastauksen turvallisuudesta
- Värikoodatut turvallisuusindikaattorit helppoon tulkintaan
- Selkeä, responsiivinen muotoilu, joka toimii eri laitteilla
- Esimerkkejä turvallisista pyynnöistä käyttäjien ohjaamiseen

### Verkkoklientin käyttäminen

1. Käynnistä sovellus:
   ```sh
   mvn spring-boot:run
   ```

2. Avaa selaimesi ja siirry osoitteeseen `http://localhost:8087`

3. Syötä laskupyyntö annettuun tekstialueeseen (esim. "Laske 24.5 ja 17.3 summa")

4. Klikkaa "Lähetä" käsitelläksesi pyyntösi

5. Näe tulokset, jotka sisältävät:
   - Sisällön turvallisuusanalyysi pyynnöstäsi
   - Laskettu tulos (jos pyyntö oli turvallinen)
   - Sisällön turvallisuusanalyysi botin vastauksesta
   - Mahdolliset turvallisuusvaroitukset, jos joko syöte tai tulos merkitään

Verkkoklientti käsittelee automaattisesti molemmat sisällön turvallisuuden tarkistusprosessit varmistaen, että kaikki vuorovaikutukset ovat turvallisia ja asianmukaisia riippumatta siitä, mitä AI-mallia käytetään.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälykäännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomaa, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäisellä kielellä tulisi katsoa auktoritatiiviseksi lähteeksi. Kriittisen tiedon kohdalla suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinkäsityksistä tai virhetulkinnoista.